# Databricks notebook source
#dbutils.secrets.help()

# COMMAND ----------

# dbutils.secrets.listScopes()

# COMMAND ----------

# dbutils.secrets.list(scope='aymane-secret-scope')

# COMMAND ----------

# client_id = "fe7d4c7b-fc4d-4753-95d9-b6666c44c391"
# tenant_id = "e85a089d-7dbe-42a2-bbbe-fccacc693d67"
# client_secret = "rN68Q~fh_DvRxEHbfqJ69ngRPilGe5ks3a~0bbd0"


# client_id = dbutils.secrets.get(scope='aymane-secret-scope',key='client-id')
# tenant_id = dbutils.secrets.get(scope='aymane-secret-scope',key='tenant-id')
# client_secret = dbutils.secrets.get(scope='aymane-secret-scope',key='client-secret')

# COMMAND ----------



# COMMAND ----------

# display(dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net"))


# COMMAND ----------

# display(spark.read.csv("abfss://demo@formula1testdl.dfs.core.windows.net/circuits.csv"))


# COMMAND ----------

# display(dbutils.fs.ls('/'))

# COMMAND ----------

# display(dbutils.fs.ls('/FileStore'))

# COMMAND ----------

# display(spark.read.csv("/FileStore/circuits.csv"))

# COMMAND ----------



# COMMAND ----------

# spark.read.csv("")

# COMMAND ----------

# display(dbutils.fs.mounts())

# COMMAND ----------

# display(dbutils.fs.mounts())

# COMMAND ----------

# display(dbutils.fs.ls("/mnt/formula1testdl/raw"))

# COMMAND ----------

#--------------------------------------------------------------------------------------------------------------

# COMMAND ----------

# # Replace these placeholders with your actual values
# storage_account_name = "formula1testdl"
# container_name = "raw"
# access_key = "C2Tk6P2sGPAq7CxWWnD6PyJhb3Y+JRvr7vHJrUjRaQbP9qMDf5geeHUWosBL69ODT3JbFsW8p9Kt+AStbtZrSg=="
# mount_point = "/mnt/aymane_starage"

# # Mount the Azure Blob Storage container using the access key
# dbutils.fs.mount(
#   source = f"wasbs://{container_name}@{storage_account_name}.blob.core.windows.net/",
#   mount_point = mount_point,
#   extra_configs = {"fs.azure.account.key." + storage_account_name + ".blob.core.windows.net": access_key}
# )


# COMMAND ----------

# display(dbutils.fs.ls("/mnt/blob_storage"))

# COMMAND ----------

circuits_df = spark.read \
    .option("header",True) \
    .csv("/mnt/blob_storage/circuits.csv")

# COMMAND ----------

circuits_df = spark.read \
    .option("header",True) \
    .option("inferSchema",True) \
    .csv("/mnt/blob_storage/circuits.csv")

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
    .csv("/mnt/blob_storage/circuits.csv")

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

from pyspark.sql.functions import col

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
.withColumnRenamed("alt", "altitude") 

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



#circuits_final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_processed.circuits")


circuits_final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_processed.aide")


# COMMAND ----------

# MAGIC %sql
# MAGIC select * from f1_processed.aide;

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