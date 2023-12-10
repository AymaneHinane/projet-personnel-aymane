# Databricks notebook source
# Replace these placeholders with your actual values
storage_account_name = "formula1testdl"
container_name = "raw"
access_key = "C2Tk6P2sGPAq7CxWWnD6PyJhb3Y+JRvr7vHJrUjRaQbP9qMDf5geeHUWosBL69ODT3JbFsW8p9Kt+AStbtZrSg=="
mount_point = "/mnt/aymane_storage/raw"

# Mount the Azure Blob Storage container using the access key
dbutils.fs.mount(
  source = f"wasbs://{container_name}@{storage_account_name}.blob.core.windows.net/",
  mount_point = mount_point,
  extra_configs = {"fs.azure.account.key." + storage_account_name + ".blob.core.windows.net": access_key}
)


# COMMAND ----------

# Replace these placeholders with your actual values
storage_account_name = "formula1testdl"
container_name = "processed"
access_key = "C2Tk6P2sGPAq7CxWWnD6PyJhb3Y+JRvr7vHJrUjRaQbP9qMDf5geeHUWosBL69ODT3JbFsW8p9Kt+AStbtZrSg=="
mount_point = "/mnt/aymane_storage/processed"

# Mount the Azure Blob Storage container using the access key
dbutils.fs.mount(
  source = f"wasbs://{container_name}@{storage_account_name}.blob.core.windows.net/",
  mount_point = mount_point,
  extra_configs = {"fs.azure.account.key." + storage_account_name + ".blob.core.windows.net": access_key}
)


# COMMAND ----------

display(dbutils.fs.ls("/mnt/aymane_storage"))

# COMMAND ----------

# Replace these placeholders with your actual values
storage_account_name = "formula1testdl"
container_name = "presentation"
access_key = "C2Tk6P2sGPAq7CxWWnD6PyJhb3Y+JRvr7vHJrUjRaQbP9qMDf5geeHUWosBL69ODT3JbFsW8p9Kt+AStbtZrSg=="
mount_point = "/mnt/aymane_storage/presentation"

# Mount the Azure Blob Storage container using the access key
dbutils.fs.mount(
  source = f"wasbs://{container_name}@{storage_account_name}.blob.core.windows.net/",
  mount_point = mount_point,
  extra_configs = {"fs.azure.account.key." + storage_account_name + ".blob.core.windows.net": access_key}
)


# COMMAND ----------

dbutils.fs.ls("/mnt/aymane_storage")

# COMMAND ----------

display(dbutils.fs.ls("/mnt/presentation"))

# COMMAND ----------

display(dbutils.fs.ls("/mnt/aymane_storage"))