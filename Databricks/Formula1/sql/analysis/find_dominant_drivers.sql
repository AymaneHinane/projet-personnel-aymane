-- Databricks notebook source


-- COMMAND ----------

use f1_presentation

-- COMMAND ----------

SELECT * FROM calculated_race_results

-- COMMAND ----------

select  driver_name,count(1) as total_races,sum(calculated_points) as total_points
from f1_presentation.calculated_race_results
group by driver_name
order by total_points desc