-- Databricks notebook source
use f1_processed;

-- COMMAND ----------

drop  table  f1_presentation.calculated_race_results ;


-- COMMAND ----------



create  table f1_presentation.calculated_race_results
using parquet
as
select races.race_year,
      drivers.name as driver_name,
      constructors.name as team_name,
      results.position,
      results.points,
      11 - results.position as calculated_points
    from f1_processed.results
    join f1_processed.drivers on (results.driver_id = drivers.driver_id)
    join f1_processed.constructors on (results.constructor_id = constructors.constructor_id)
    join f1_processed.races on (results.race_id = races.race_id)
where results.position  <= 10

-- COMMAND ----------

select * from f1_presentation.calculated_race_results

-- COMMAND ----------



-- COMMAND ----------

select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
group by driver_name
having count(1) > 50
order by total_points desc

-- COMMAND ----------

select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
where race_year between 2011 and 2020
group by driver_name 
having count(1) > 50
order by total_points desc

-- COMMAND ----------

select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
where race_year between 2001 and 2010
group by driver_name 
having count(1) >= 50
order by total_points desc

-- COMMAND ----------

select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
group by driver_name
having count(1) >= 100
order by avg_point desc

-- COMMAND ----------

select  team_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
where race_year between 2011 and 2020
group by team_name
having count(1) >= 100
order by avg_point desc

-- COMMAND ----------

select  team_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
where race_year between 2001 and 2011
group by team_name
having count(1) >= 100
order by avg_point desc

-- COMMAND ----------

--visualtion

-- COMMAND ----------

--best driver

select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point,
rank() over(order by AVG(calculated_points) desc) driver_rank
from f1_presentation.calculated_race_results
group by driver_name 
having count(1) >= 50
order by avg_point desc

-- COMMAND ----------

create or replace temp view v_dominant_drivers
as
select  driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point,
rank() over(order by AVG(calculated_points) desc) driver_rank
from f1_presentation.calculated_race_results
group by driver_name 
having count(1) >= 50
order by total_points desc

-- COMMAND ----------

select  race_year,driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
group by race_year ,driver_name
order by avg_point,avg_point desc

-- COMMAND ----------

--best driver of all time
select  race_year,driver_name,count(1) as total_races,
sum(calculated_points) as total_points,
avg(calculated_points) as avg_point
from f1_presentation.calculated_race_results
where driver_name in (select driver_name from v_dominant_drivers where driver_rank <= 10)
group by race_year ,driver_name
order by race_year,avg_point desc


-- COMMAND ----------

