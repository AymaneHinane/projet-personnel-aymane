# Databricks notebook source
spark.conf.set(
    "fs.azure.account.key.formula1testdl.dfs.core.windows.net",
    "C2Tk6P2sGPAq7CxWWnD6PyJhb3Y+JRvr7vHJrUjRaQbP9qMDf5geeHUWosBL69ODT3JbFsW8p9Kt+AStbtZrSg=="
)

# COMMAND ----------

dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net/")

# COMMAND ----------

display(dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net"))

# COMMAND ----------

display(spark.read.csv("abfss://demo@formula1testdl.dfs.core.windows.net/circuits.csv"))