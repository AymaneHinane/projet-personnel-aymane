--create database DEMO_DB;

USE DATABASE DEMO_DB;
-- create integration object that contains the access information
CREATE or replace STORAGE INTEGRATION azure_integration
  TYPE = EXTERNAL_STAGE
  STORAGE_PROVIDER = AZURE
  ENABLED = TRUE
  AZURE_TENANT_ID = 'f93d5f40-88c0-4650-b8f2-cc4ec3ef6a10'
  STORAGE_ALLOWED_LOCATIONS = ('azure://storageaccountaymane.blob.core.windows.net/snoawflakecsv', 'azure://storageaccountsnow.blob.core.windows.net/snoawflakejson');
  

    
-- Describe integration object to provide access
DESC STORAGE integration azure_integration;

  
---- Create file format & stage objects ----

-- create file format
create or replace file format DEMO_DB.public.fileformat_azure
    TYPE = CSV
    FIELD_DELIMITER = ','
    SKIP_HEADER = 1;

-- create stage object
create or replace stage DEMO_DB.public.stage_azure
   // STORAGE_INTEGRATION = azure_integration
    URL = 'azure://storageaccountaymane.blob.core.windows.net/snoawflakecsv'
     CREDENTIALS=(
          AZURE_SAS_TOKEN='?sv=2022-11-02&ss=bfqt&srt=co&sp=rwdlacupiytfx&se=2023-11-04T03:34:05Z&st=2023-11-03T19:34:05Z&spr=https&sig=paLVCMNr4a9ZrJWXnvhwKnyaZ4nELv0GofwHgg2HPUM%3D')
    FILE_FORMAT = fileformat_azure;
    
-- list files
LIST @DEMO_DB.public.stage_azure;


select * from @DEMO_DB.public.stage_azure;

--query files
SELECT 
$1,
$2,
$3,
$4,
$5,
$6,
$7,
$8,
$9,
$10,
$11,
$12,
$13,
$14,
$15,
$16,
$17,
$18,
$19,
$20
FROM @demo_db.public.stage_azure;
