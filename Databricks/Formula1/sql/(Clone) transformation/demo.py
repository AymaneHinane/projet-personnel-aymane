# Databricks notebook source
display(spark.read.parquet("/mnt/formula1testdl/processed/races"))

# COMMAND ----------

races_df = spark.read.parquet("/mnt/formula1testdl/processed/races")

# COMMAND ----------

#races_filtered_df = races_df.filter("race_year = 2019")

#races_filtered_df = races_df.filter(races_df["race_year"] == 2019)

#races_filtered_df = races_df.filter("race_year = 2019 and round <= 5 ")

races_filtered_df = races_df.filter((races_df["race_year"] == 2019) & (races_df["round"] <= 5))

# COMMAND ----------

display(races_filtered_df)

# COMMAND ----------



# COMMAND ----------

#----------------------------------------------------------------------------------------------------------------

# COMMAND ----------

races_df = spark.read.parquet("/mnt/formula1testdl/processed/races").filter("race_year = 2019") \
        .withColumnRenamed("name","race_name")

circuits_df = spark.read.parquet("/mnt/formula1testdl/processed/circuits") \
    .filter("circuit_id < 70") \
    .withColumnRenamed("name","circuit_name")


# COMMAND ----------

display(races_df)

# COMMAND ----------

display(circuits_df)

# COMMAND ----------

# race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id ) \
#     .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country,races_df.race_name,races_df.round)


race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"inner" ) \
    .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country,races_df.race_name,races_df.round)

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

race_circuits_df.select("circuit_name").show()

# COMMAND ----------

#left Outer join
race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"left" ) \
    .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country,races_df.race_name,races_df.round)  

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

#right Outer join
race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"right" ) \
    .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country,races_df.race_name,races_df.round) 

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

#full outer join :    left join + right join + inner join
race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"full" ) \
    .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country,races_df.race_name,races_df.round) 

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

## Semi join : do inner join but return only the left column

race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"semi" ) \
    .select(circuits_df.circuit_name,circuits_df.location,circuits_df.country) 


# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

##Anti joins    all in the left that do not exist on right


race_circuits_df = circuits_df.join(races_df,races_df.circuit_id == circuits_df.circuit_id,"anti" )

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

race_circuits_df = races_df.join(circuits_df,races_df.circuit_id == circuits_df.circuit_id,"anti" )

# COMMAND ----------

display(race_circuits_df)

# COMMAND ----------

