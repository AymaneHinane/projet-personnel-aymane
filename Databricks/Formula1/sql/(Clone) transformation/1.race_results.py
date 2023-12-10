# Databricks notebook source
circuits_df = spark.read.parquet("/mnt/aymane_storage/processed/circuits") \
    .withColumnRenamed("location", "circuit_location") 
display(circuits_df)

# COMMAND ----------

constructors_df = spark.read.parquet("/mnt/aymane_storage/processed/constructors") \
    .withColumnRenamed("name", "team") 
display(constructors_df)

# COMMAND ----------

drivers_df = spark.read.parquet("/mnt/aymane_storage/processed/drivers") \
.withColumnRenamed("number", "driver_number") \
.withColumnRenamed("name", "driver_name") \
.withColumnRenamed("nationality", "driver_nationality") 

display(drivers_df)

# COMMAND ----------

races_df = spark.read.parquet("/mnt/aymane_storage/processed/races") \
    .withColumnRenamed("name", "race_name") \
.withColumnRenamed("race_timestamp", "race_date") 
display(races_df)

# COMMAND ----------

results_df = spark.read.parquet("/mnt/aymane_storage/processed/results") \
    .withColumnRenamed("time", "race_time") 
display(results_df)

# COMMAND ----------

race_circuits_df = races_df.join(circuits_df, races_df.circuit_id == circuits_df.circuit_id, "inner") \
.select(races_df.race_id, races_df.race_year, races_df.race_name, races_df.race_date, circuits_df.circuit_location)

# COMMAND ----------

race_results_df = results_df.join(race_circuits_df, results_df.race_id == race_circuits_df.race_id) \
                            .join(drivers_df, results_df.driver_id == drivers_df.driver_id) \
                            .join(constructors_df, results_df.constructor_id == constructors_df.constructor_id)

# COMMAND ----------

from pyspark.sql.functions import current_timestamp

# COMMAND ----------

final_df = race_results_df.select("race_year", "race_name", "race_date", "circuit_location", "driver_name", "driver_number", "driver_nationality","team", "grid", "fastest_lap", "race_time", "points", "position") \
.withColumn("created_date", current_timestamp())

# COMMAND ----------

display(final_df.filter("race_year == 2020 and race_name == 'Abu Dhabi Grand Prix'").orderBy(final_df.points.desc()))

# COMMAND ----------

#final_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/race_results")

final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_presentation.race_results")

# COMMAND ----------

display(spark.read.parquet("/mnt/aymane_storage/processed/race_results"))