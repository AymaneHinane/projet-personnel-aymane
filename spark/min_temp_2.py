#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Sat Sep 23 23:48:27 2023

@author: aymanehinane
"""
from pyspark.sql import SparkSession
from pyspark.sql import functions as func
from pyspark.sql.types import StructType, StructField, StringType, IntegerType, FloatType 

spark = SparkSession.builder.appName("MinTemperatures").getOrCreate()

schema = StructType([ \
                     StructField("stationID", StringType(), True), \
                     StructField("date", IntegerType(), True), \
                     StructField("measure_type", StringType(), True), \
                     StructField("temperature", FloatType(), True)])

    
df = spark.read.schema(schema).csv("/Users/aymanehinane/Desktop/spark/1800.csv")

df.printSchema()

df.show()

minTemps = df.filter(df.measure_type == 'TMIN')

minTemps.show()

stationTemps = minTemps.select("stationID","temperature")
stationTemps.show()



minTempsByStation  = stationTemps.groupBy("stationID").agg(func.min("temperature").alias("min_temperature"))
minTempsByStation.show()

minTempsByStationF = minTempsByStation.withColumn("temperature", 
                                                  func.round(  func.col("min_temperature")*0.1*(9.0/5.0)+32.0 , 2) ) \
                                                  .select("stationID","temperature") \
                                                  .sort("temperature")
minTempsByStationF.show()