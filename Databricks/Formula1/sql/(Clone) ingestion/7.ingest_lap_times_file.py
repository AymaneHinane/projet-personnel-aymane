# Databricks notebook source
from pyspark.sql.types import StructType, StructField, IntegerType, StringType

lap_times_schema = StructType(fields=[StructField("raceId", IntegerType(), False),
                                      StructField("driverId", IntegerType(), True),
                                      StructField("lap", IntegerType(), True),
                                      StructField("position", IntegerType(), True),
                                      StructField("time", StringType(), True),
                                      StructField("milliseconds", IntegerType(), True)
                                     ])


lap_times_df = spark.read \
.schema(lap_times_schema) \
.csv("/mnt/blob_storage/lap_times")                                    

# COMMAND ----------

from pyspark.sql.functions import current_timestamp

final_df = lap_times_df.withColumnRenamed("driverId", "driver_id") \
.withColumnRenamed("raceId", "race_id") \
.withColumn("ingestion_date", current_timestamp())

# COMMAND ----------

#final_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/processedlap_times")

final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_processed.processedlap_times")