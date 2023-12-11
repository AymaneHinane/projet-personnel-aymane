#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Sat Sep 23 16:37:04 2023

@author: aymanehinane
"""

from pyspark.sql import SparkSession
from pyspark.sql import Row


spark = SparkSession.builder.appName("SparkSQL").getOrCreate()

lines = spark.sparkContext.textFile("/Users/aymanehinane/Desktop/dataTest/spark/fakefriends.csv")

def mapper(line):
    fields = line.split(',')
    return Row(id=int(fields[0]) ,  name = str(fields[1].encode("utf-8")) , \
               age = int(fields[2]), numFriends = int(fields[3]) )
    
people = lines.map(mapper)

shemaPeople = spark.createDataFrame(people).cache()
shemaPeople.createOrReplaceTempView("people")

teenagers = spark.sql("select * from people where age >= 13 and age <= 19 ")

for teen in teenagers.collect():
    print(teen)
    
shemaPeople.groupBy("age").count().orderBy("age").show() #.show()

spark.stop();