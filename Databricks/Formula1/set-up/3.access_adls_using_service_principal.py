# Databricks notebook source
client_id = "d4b992f7-4e8c-4b25-99a5-e3d68f9e8a9c"
tenant_id = "e85a089d-7dbe-42a2-bbbe-fccacc693d67"
client_secret="eMg8Q~BBah-umzGUwFtdY9jQbBfUXZhsF5HbGcCn"


# COMMAND ----------

spark.conf.set("fs.azure.account.auth.type.formula1testdl.dfs.core.windows.net", "OAuth")
spark.conf.set("fs.azure.account.oauth.provider.type.formula1testdl.dfs.core.windows.net", "org.apache.hadoop.fs.azurebfs.oauth2.ClientCredsTokenProvider")
spark.conf.set("fs.azure.account.oauth2.client.id.formula1testdl.dfs.core.windows.net", client_id)
spark.conf.set("fs.azure.account.oauth2.client.secret.formula1testdl.dfs.core.windows.net", client_secret)
spark.conf.set("fs.azure.account.oauth2.client.endpoint.formula1testdl.dfs.core.windows.net", f"https://login.microsoftonline.com/{tenant_id}/oauth2/token")

# COMMAND ----------

display(dbutils.fs.ls("abfss://demo@formula1testdl.dfs.core.windows.net"))

# COMMAND ----------

display(spark.read.csv("abfss://demo@formula1testdl.dfs.core.windows.net/circuits.csv"))