-- Databricks notebook source
show databases;

-- COMMAND ----------

use f1_processed

-- COMMAND ----------

select * from drivers limit 10;

-- COMMAND ----------

select name,dob as date_of_birth from drivers where nationality = 'British' and dob >= '1990-01-01' order by nationality asc, dob desc;

-- COMMAND ----------

select name,dob as date_of_birth from drivers 
where (nationality = 'British' and dob >= '1990-01-01') or nationality = 'Indian'
order by nationality asc, dob desc;

-- COMMAND ----------

select *,concat(driver_ref,'-',code ) as new_driver_ref from drivers;

-- COMMAND ----------

select *,split(name,' ') from drivers;

-- COMMAND ----------

select *,split(name,' ')[0] forename,split(name,' ')[1] surname from drivers;

-- COMMAND ----------

select * , current_timestamp() from drivers;

-- COMMAND ----------

select * , date_format(dob,'dd--MM--yyyy') from drivers;

-- COMMAND ----------

select nationality,name,dob,RANK() OVER(partition by nationality order by dob desc) as age_rank from drivers order by nationality,age_rank

-- COMMAND ----------

desc driver_standings 