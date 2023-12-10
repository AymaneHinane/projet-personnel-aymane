# Databricks notebook source
race_results_df = spark.read.parquet("/mnt/aymane_storage/processed/race_results")

# COMMAND ----------

from pyspark.sql.functions import sum, when, count, col

constructor_standings_df = race_results_df \
.groupBy("race_year", "team") \
.agg(sum("points").alias("total_points"),
     count(when(col("position") == 1, True)).alias("wins"))

# COMMAND ----------

display(constructor_standings_df.filter("race_year = 2020"))

# COMMAND ----------

from pyspark.sql.window import Window
from pyspark.sql.functions import desc, rank, asc

constructor_rank_spec = Window.partitionBy("race_year").orderBy(desc("total_points"), desc("wins"))
final_df = constructor_standings_df.withColumn("rank", rank().over(constructor_rank_spec))

# COMMAND ----------

display(final_df.filter("race_year = 2020"))

# COMMAND ----------

display(final_df)

# COMMAND ----------

#final_df.write.mode("overwrite").parquet("/mnt/aymane_storage/processed/constructor_standings")

final_df.write.mode("overwrite").format("parquet").saveAsTable("f1_presentation.constructor_standings")