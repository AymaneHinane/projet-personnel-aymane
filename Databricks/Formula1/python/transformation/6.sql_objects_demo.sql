-- Databricks notebook source


CREATE DATABASE demo;

-- COMMAND ----------


CREATE DATABASE IF NOT EXISTS demo;

-- COMMAND ----------

show databases

-- COMMAND ----------

describe database demo

-- COMMAND ----------

DESCRIBE DATABASE EXTENDED demo;

-- COMMAND ----------

select current_database()

-- COMMAND ----------

show tables;

-- COMMAND ----------

show tables in demo;

-- COMMAND ----------

-- use demo

-- COMMAND ----------

-- MAGIC %python
-- MAGIC
-- MAGIC race_results_df = spark.read.parquet("/mnt/aymane_storage/processed/race_results")

-- COMMAND ----------

-- MAGIC %python
-- MAGIC display(race_results_df);

-- COMMAND ----------

-- MAGIC %python
-- MAGIC
-- MAGIC race_results_df.write.format("parquet").saveAsTable("demo.race_results_python")

-- COMMAND ----------

select * from demo.race_results_python

-- COMMAND ----------

use demo;
show tables;

-- COMMAND ----------

desc race_results_python;

-- COMMAND ----------

desc extended race_results_python;

-- COMMAND ----------

select * from demo.race_results_python where race_year = 2020;

-- COMMAND ----------

--managed table
create table race_results_sql
as
select * from demo.race_results_python where race_year = 2020;

-- COMMAND ----------

select * from race_results_sql

-- COMMAND ----------

desc extended demo.race_results_sql;

-- COMMAND ----------

-- MAGIC %python
-- MAGIC
-- MAGIC # create external tables
-- MAGIC
-- MAGIC race_results_df.write.format("parquet").option("path","/mnt/aymane_storage/processed/race_results_ext_py").saveAsTable("demo.race_results_ext_py")

-- COMMAND ----------


desc extended demo.race_results_ext_py

-- COMMAND ----------

create table demo.race_results_ext_sql(
  race_year  int,
  race_name  string,
  race_date timestamp,
  circuit_location string,
  driver_name string,
  driver_number int,
  driver_nationality string,
  team string,
  grid int,
  fastest_lap int,
  race_time string,
  points float,
  position int,
  created_date timestamp
)
using parquet
location "/mnt/aymane_storage/presentation/race_results_ext_sql"

-- COMMAND ----------

drop table  demo.race_results_ext_sql;

-- COMMAND ----------

show tables in demo;

-- COMMAND ----------

insert into demo.race_results_ext_sql
select * from race_results_ext_py where race_year = 2020

-- COMMAND ----------

select * from race_results_ext_py;

-- COMMAND ----------

create temp view v_race_results 
as
select * from demo.race_results_python
where race_year = 2018;

-- COMMAND ----------

select * from v_race_results

-- COMMAND ----------

create or replace GLOBAL temp view gv_race_results 
as
select * from demo.race_results_python
where race_year = 2018;

-- COMMAND ----------

show tables;

-- COMMAND ----------

show tables in global_temp;

-- COMMAND ----------

select * from global_temp.gv_race_results

-- COMMAND ----------

-- create permanent view

create or replace view demo.pv_race_results
as
select * from demo.race_results_python
where race_year = 2000;

-- COMMAND ----------

show tables;