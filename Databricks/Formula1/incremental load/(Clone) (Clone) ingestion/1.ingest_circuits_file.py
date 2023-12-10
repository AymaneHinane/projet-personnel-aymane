# Databricks notebook source
#file date

# dbutils.widgets.text("p_data_source","")
# v_data_source = dbutils.widgets.get("p_data_source")


# COMMAND ----------

#file date

# dbutils.widgets.text("p_file_data","2021-03-21")
# v_file_date = dbutils.widgets.get("p_file_date")

v_file_date = "2021-03-21"


# COMMAND ----------

# circuits_df = spark.read \
#     .option("header",True) \
#     .csv("/mnt/blob_storage/circuits.csv")

# COMMAND ----------

circuits_df = spark.read \
    .option("header",True) \
    .option("inferSchema",True) \
    .csv(f"/mnt/blob_storage/{v_file_date}/circuits.csv")

# COMMAND ----------

from pyspark.sql.types import StructType,StructField,IntegerType,StringType,DoubleType;

circuits_schema = StructType(fields=[StructField("circuitId", IntegerType(), False),
                                     StructField("circuitRef", StringType(), True),
                                     StructField("name", StringType(), True),
                                     StructField("location", StringType(), True),
                                     StructField("country", StringType(), True),
                                     StructField("lat", DoubleType(), True),
                                     StructField("lng", DoubleType(), True),
                                     StructField("alt", IntegerType(), True),
                                     StructField("url", StringType(), True)
])

circuits_df = spark.read \
    .option("header",True) \
    .schema(circuits_schema) \
    .csv(f"/mnt/blob_storage/{v_file_date}/circuits.csv")

# COMMAND ----------

type(circuits_df)

# COMMAND ----------

circuits_df.show()

# COMMAND ----------

display(circuits_df)

# COMMAND ----------

circuits_df.printSchema()

# COMMAND ----------

circuits_df.describe().show()

# COMMAND ----------

from pyspark.sql.functions import col , lit

circuits_selected_df = circuits_df.select(col("circuitId"), col("circuitRef"), col("name"), col("location"),\
     col("country"), col("lat"), col("lng"), col("alt"))

# COMMAND ----------

circuits_selected_df = circuits_df.select(col("circuitId"), col("circuitRef"), col("name"), col("location"),\
     col("country").alias("race_country"), col("lat"), col("lng"), col("alt"))

# COMMAND ----------

circuits_selected_df = circuits_df.select(col("circuitId"), col("circuitRef"), col("name"), col("location"),\
     col("country"), col("lat"), col("lng"), col("alt"))

# COMMAND ----------

circuits_renamed_df = circuits_selected_df.withColumnRenamed("circuitId", "circuit_id") \
.withColumnRenamed("circuitRef", "circuit_ref") \
.withColumnRenamed("lat", "latitude") \
.withColumnRenamed("lng", "longitude") \
.withColumnRenamed("alt", "altitude") \
.withColumn("data_source", lit("blob_storage")) \
.withColumn("file_date",lit(v_file_date))  

# COMMAND ----------

display(circuits_renamed_df)

# COMMAND ----------

from pyspark.sql.functions import current_timestamp,lit

# circuits_final_df = circuits_renamed_df.withColumn("ingestion_date", current_timestamp()) \
#     .withColumn("env", lit("Production"))

circuits_final_df = circuits_renamed_df.withColumn("ingestion_date", current_timestamp())

display(circuits_final_df)

# COMMAND ----------

#circuits_final_df.write.mode("overwrite").parquet("/mnt/formula1testdl/processed/circuits") 

# COMMAND ----------

# MAGIC %sql
# MAGIC use f1_processed;

# COMMAND ----------

#circuits_final_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/circuits")



circuits_final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_processed.circuits")


# COMMAND ----------

# MAGIC %sql
# MAGIC select * from f1_processed.circuits;

# COMMAND ----------

# MAGIC %fs
# MAGIC ls /mnt/formula1testdl/processed/circuits

# COMMAND ----------

df = spark.read.parquet("/mnt/formula1testdl/processed/circuits")

# COMMAND ----------

display(df)

# COMMAND ----------

display(spark.read.parquet("/mnt/formula1testdl/processed/circuits"))