# Databricks notebook source
display(dbutils.fs.ls("/mnt/blob_storage"))

# COMMAND ----------

constructors_schema = "constructorId INT, constructorRef STRING, name STRING, nationality STRING, url STRING"

constructor_df = spark.read \
.schema(constructors_schema) \
.json("/mnt/blob_storage/constructors.json")

# COMMAND ----------

display(constructor_df)

# COMMAND ----------

from pyspark.sql.functions import col

constructor_dropped_df = constructor_df.drop(col('url'))

display(constructor_dropped_df)

# COMMAND ----------

from pyspark.sql.functions import current_timestamp

constructor_final_df = constructor_dropped_df.withColumnRenamed("constructorId", "constructor_id") \
                                             .withColumnRenamed("constructorRef", "constructor_ref") \
                                             .withColumn("ingestion_date", current_timestamp())

                                             

# COMMAND ----------

constructor_final_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/constructors")

# COMMAND ----------



# COMMAND ----------

display(spark.read.parquet("/mnt/formula1testdl/processed/constructors"))