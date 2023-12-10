# Databricks notebook source
v_file_date = "2021-03-21"

# COMMAND ----------

from pyspark.sql.types import StructType, StructField, IntegerType, StringType, DateType

races_schema = StructType(fields=[StructField("raceId", IntegerType(), False),
                                  StructField("year", IntegerType(), True),
                                  StructField("round", IntegerType(), True),
                                  StructField("circuitId", IntegerType(), True),
                                  StructField("name", StringType(), True),
                                  StructField("date", DateType(), True),
                                  StructField("time", StringType(), True),
                                  StructField("url", StringType(), True) 
])


# COMMAND ----------

display(dbutils.fs.ls("/mnt/blob_storage"))

# COMMAND ----------

races_df = spark.read \
.option("header", True) \
.schema(races_schema) \
.csv(f"/mnt/blob_storage/{v_file_date}/races.csv")

# COMMAND ----------

display(races_df )

# COMMAND ----------

from pyspark.sql.functions import current_timestamp, to_timestamp, concat, col, lit

races_with_timestamp_df = races_df.withColumn("ingestion_date", current_timestamp()) \
                                  .withColumn("race_timestamp", to_timestamp(concat(col('date'), lit(' '), col('time')), 'yyyy-MM-dd HH:mm:ss')) \
                                .withColumn("data_source", lit("blob_storage")) \
                                .withColumn("file_date",lit(v_file_date))  


# COMMAND ----------

races_selected_df = races_with_timestamp_df.select(col('raceId').alias('race_id'), col('year').alias('race_year'), 
                                                   col('round'), col('circuitId').alias('circuit_id'),col('name'), col('ingestion_date'), col('race_timestamp'))

# COMMAND ----------

display(races_selected_df)

# COMMAND ----------

#races_selected_df.write.mode("overwrite").parquet("/mnt/formula1testdl/processed/races") 

# COMMAND ----------

#races_selected_df.write.mode("overwrite").partitionBy("race_year").parquet("/mnt/formula1testdl/processed/races") 

# COMMAND ----------

#races_selected_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/races")

races_selected_df.write.mode("overwrite").format("parquet").saveAsTable("f1_processed.races")

# COMMAND ----------

# MAGIC %fs
# MAGIC ls /mnt/formula1testdl/processed/races

# COMMAND ----------

display(spark.read.parquet('/mnt/formula1testdl/processed/races'))

# COMMAND ----------

