# Databricks notebook source

v_file_date = "2021-04-18"

# COMMAND ----------

spark.read.json("dbfs:/mnt/aymane_storage/raw/2021-03-21/results.json").createOrReplaceTempView("results_cutover")

# COMMAND ----------

# MAGIC %sql
# MAGIC select * from results_cutover

# COMMAND ----------

spark.read.json("dbfs:/mnt/aymane_storage/raw/2021-03-28/results.json").createOrReplaceTempView("results_w1")

# COMMAND ----------

# MAGIC %sql
# MAGIC select * from results_w1

# COMMAND ----------

spark.read.json("dbfs:/mnt/aymane_storage/raw/2021-04-18/results.json").createOrReplaceTempView("results_w2")

# COMMAND ----------

# MAGIC %sql
# MAGIC select * from results_w2

# COMMAND ----------

from pyspark.sql.types import StructType, StructField, IntegerType, StringType, FloatType

results_schema = StructType(fields=[StructField("resultId", IntegerType(), False),
                                    StructField("raceId", IntegerType(), True),
                                    StructField("driverId", IntegerType(), True),
                                    StructField("constructorId", IntegerType(), True),
                                    StructField("number", IntegerType(), True),
                                    StructField("grid", IntegerType(), True),
                                    StructField("position", IntegerType(), True),
                                    StructField("positionText", StringType(), True),
                                    StructField("positionOrder", IntegerType(), True),
                                    StructField("points", FloatType(), True),
                                    StructField("laps", IntegerType(), True),
                                    StructField("time", StringType(), True),
                                    StructField("milliseconds", IntegerType(), True),
                                    StructField("fastestLap", IntegerType(), True),
                                    StructField("rank", IntegerType(), True),
                                    StructField("fastestLapTime", StringType(), True),
                                    StructField("fastestLapSpeed", FloatType(), True),
                                    StructField("statusId", StringType(), True)])


results_df = spark.read \
.schema(results_schema) \
.json(f"/mnt/blob_storage/{v_file_date}/results.json")







# COMMAND ----------

from pyspark.sql.functions import current_timestamp,lit

results_with_columns_df = results_df.withColumnRenamed("resultId", "result_id") \
                                    .withColumnRenamed("raceId", "race_id") \
                                    .withColumnRenamed("driverId", "driver_id") \
                                    .withColumnRenamed("constructorId", "constructor_id") \
                                    .withColumnRenamed("positionText", "position_text") \
                                    .withColumnRenamed("positionOrder", "position_order") \
                                    .withColumnRenamed("fastestLap", "fastest_lap") \
                                    .withColumnRenamed("fastestLapTime", "fastest_lap_time") \
                                    .withColumnRenamed("fastestLapSpeed", "fastest_lap_speed") \
                                    .withColumn("ingestion_date", current_timestamp()) \
                                    .withColumn("data_source", lit("blob_storage")) \
                                    .withColumn("file_date",lit(v_file_date))  


# COMMAND ----------

from pyspark.sql.functions import col

results_final_df = results_with_columns_df.drop(col("statusId"))



# COMMAND ----------

display(results_final_df)

# COMMAND ----------

for race_id_list in results_final_df.select("race_id").distinct().collect():
    if (spark._jsparkSession.catalog().tableExists("f1_processed.results")):  #execute only if table results exists
       spark.sql(f"ALTER TABLE f1_processed.results drop if exists PARTITION (race_id = {race_id_list.race_id})")

# COMMAND ----------

#results_final_df.write.mode("overwrite").partitionBy("race_id").parquet("/mnt/aymane_storage/processed/results")


results_final_df.write.mode("append").partitionBy('race_id').format("parquet").saveAsTable("f1_processed.results")

# COMMAND ----------

# MAGIC %sql
# MAGIC
# MAGIC select race_id,count(*) from f1_processed.results group by race_id;

# COMMAND ----------

# MAGIC %sql
# MAGIC drop table f1_processed.results;

# COMMAND ----------

spark.conf.set("spark.sql.sources.partitionOverwriteMode","dynamic")

# COMMAND ----------


# results_with_columns_df = results_df.withColumnRenamed("resultId", "result_id") \
#                                     .withColumnRenamed("raceId", "race_id") \
#                                     .withColumnRenamed("driverId", "driver_id") \
#                                     .withColumnRenamed("constructorId", "constructor_id") \
#                                     .withColumnRenamed("positionText", "position_text") \
#                                     .withColumnRenamed("positionOrder", "position_order") \
#                                     .withColumnRenamed("fastestLap", "fastest_lap") \
#                                     .withColumnRenamed("fastestLapTime", "fastest_lap_time") \
#                                     .withColumnRenamed("fastestLapSpeed", "fastest_lap_speed") \
#                                     .withColumn("ingestion_date", current_timestamp()) \
#                                     .withColumn("data_source", lit("blob_storage")) \
#                                     .withColumn("file_date",lit(v_file_date))  


results_final_df = results_final_df.select("result_id","driver_id","constructor_id","position","position_text",
                                           "position_order","time","milliseconds","fastest_lap","rank","fastest_lap_time","fastest_lap_speed","race_id")

# COMMAND ----------

if(spark._jsparkSession.catalog().tableExists("f1_processed.results")):
    results_final_df.write.mode("overwrite").insertInto("f1_processed.results")
else:
    results_final_df.write.mode("overwrite").partitionBy('race_id').format("parquet").saveAsTable("f1_processed.results")

# COMMAND ----------

