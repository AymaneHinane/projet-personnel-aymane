# Databricks notebook source
spark.conf.set("fs.azure.account.auth.type.formula1testdl.dfs.core.windows.net", "SAS")
spark.conf.set("fs.azure.sas.token.provider.type.formula1testdl.dfs.core.windows.net", "org.apache.hadoop.fs.azurebfs.sas.FixedSASTokenProvider")
spark.conf.set("fs.azure.sas.fixed.token.formula1testdl.dfs.core.windows.net", "sp=rl&st=2023-11-13T17:13:34Z&se=2023-11-30T01:13:34Z&spr=https&sv=2022-11-02&sr=c&sig=jepdqI7Y%2BBmx51L9yaZegNrhs4oAIys3ENNRQ3rCc6c%3D")

# COMMAND ----------

dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net")

# COMMAND ----------

display(dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net"))

# COMMAND ----------

display(spark.read.csv("abfss://demo@formula1testdl.dfs.core.windows.net/circuits.csv"))

# COMMAND ----------

display(dbutils.fs.ls('/'))

# COMMAND ----------

display(dbutils.fs.ls('/FileStore'))

# COMMAND ----------

display(spark.read.csv('dbfs:/FileStore/circuits.csv'))