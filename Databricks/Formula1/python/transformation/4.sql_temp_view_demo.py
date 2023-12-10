# Databricks notebook source
race_result_df = spark.read.parquet("/mnt/aymane_storage/processed/race_results")

# COMMAND ----------

display(race_result_df)

# COMMAND ----------


#local view
#race_result_df.createTempView("v_race_results")

race_result_df.createOrReplaceTempView("v_race_results")

# COMMAND ----------

# MAGIC %sql
# MAGIC select * from v_race_results where race_year = 2020

# COMMAND ----------

race_results_2019_df = spark.sql("select * from v_race_results where race_year = 2019")

# COMMAND ----------

display(race_results_2019_df)

# COMMAND ----------

p_race_year = 2020

race_results_2020_df = spark.sql(f"select * from v_race_results where race_year = {p_race_year}")

display(race_results_2020_df)

# COMMAND ----------

#Globale view

race_result_df.createOrReplaceGlobalTempView("gv_race_results")

# COMMAND ----------

# MAGIC %sql 
# MAGIC
# MAGIC show tables;

# COMMAND ----------

# MAGIC %sql
# MAGIC select * from gv_race_results

# COMMAND ----------

spark.sql("select * from gv_race_results").show()

# COMMAND ----------

