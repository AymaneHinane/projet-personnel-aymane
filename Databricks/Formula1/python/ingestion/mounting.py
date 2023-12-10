# Databricks notebook source
client_id = dbutils.secrets.get(scope='aymane-secret-scope',key='client-id')
tenant_id = dbutils.secrets.get(scope='aymane-secret-scope',key='tenant-id')
client_secret = dbutils.secrets.get(scope='aymane-secret-scope',key='client-secret')

# COMMAND ----------

configs = {"fs.azure.account.auth.type": "OAuth",
          "fs.azure.account.oauth.provider.type": "org.apache.hadoop.fs.azurebfs.oauth2.ClientCredsTokenProvider",
          "fs.azure.account.oauth2.client.id": client_id,
          "fs.azure.account.oauth2.client.secret": client_secret,
          "fs.azure.account.oauth2.client.endpoint": f"https://login.microsoftonline.com/{tenant_id}/oauth2/token"}   

# COMMAND ----------

dbutils.fs.mount(
  source = "abfss://demo@formula1testdl.dfs.core.windows.net/",
  mount_point = "/mnt/formula1testdl/raw",
  extra_configs = configs)

# COMMAND ----------

display(dbutils.fs.ls("/mnt/formula1testdl"))

# COMMAND ----------

# For example, you can recursively delete a directory
dbutils.fs.rm("/mnt/formula1testdl/demo/", True)



# COMMAND ----------

