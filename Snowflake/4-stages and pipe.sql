use schema PROJECTETLWORKFLOW.LANDING_ZONE;



-- CREATE OR REPLACE STAGE PROJECTETLWORKFLOW.LANDING_ZONE.delta_customer_azure
--     url='azure://snowflakedltest.blob.core.windows.net/snowflakedlk/customer';

-- List @PROJECTETLWORKFLOW.LANDING_ZONE.delta_customer_azure


-- create integration object that contains the access information
CREATE OR REPLACE STORAGE INTEGRATION azure_snowpipe_integration
  TYPE = EXTERNAL_STAGE
  STORAGE_PROVIDER = AZURE
  ENABLED = TRUE
  AZURE_TENANT_ID =  'e85a089d-7dbe-42a2-bbbe-fccacc693d67'
  STORAGE_ALLOWED_LOCATIONS = ( 'azure://snowflakedlk.blob.core.windows.net/snowflakedl2');


    
-- Describe integration object to provide access
DESC STORAGE integration azure_snowpipe_integration;


--go to Access Control (IAM)

---- Create file format & stage objects ----

-- create file format

create or replace file format fileformat_azure
    TYPE = CSV
    FIELD_DELIMITER = ','
    SKIP_HEADER = 1;

-- create stage object
create or replace stage delta_orders_azure
    STORAGE_INTEGRATION = azure_snowpipe_integration
    URL = 'azure://snowflakedlk.blob.core.windows.net/snowflakedl2/order'
    FILE_FORMAT = fileformat_azure;


list @delta_orders_azure

create or replace stage delta_customer_azure
    STORAGE_INTEGRATION = azure_snowpipe_integration
    URL = 'azure://snowflakedlk.blob.core.windows.net/snowflakedl2/customer'
    FILE_FORMAT = fileformat_azure;

list @delta_customer_azure


create or replace stage delta_items_azure
    STORAGE_INTEGRATION = azure_snowpipe_integration
    URL = 'azure://snowflakedlk.blob.core.windows.net/snowflakedl2/item'
    FILE_FORMAT = fileformat_azure;

list @delta_items_azure


select $1,$2,$3,$4,$5,$6,$7 from @delta_customer_azure

show stages



CREATE OR REPLACE NOTIFICATION INTEGRATION etlworkflow_event
  ENABLED = true
  TYPE = QUEUE
  NOTIFICATION_PROVIDER = AZURE_STORAGE_QUEUE
  AZURE_STORAGE_QUEUE_PRIMARY_URI = 'https://snowflakedlk.queue.core.windows.net/snowflakequeue'
  AZURE_TENANT_ID = 'e85a089d-7dbe-42a2-bbbe-fccacc693d67';


  DROP NOTIFICATION INTEGRATION IF EXISTS etlworkflow_event;

  
  -- Register Integration
  
  DESC notification integration etlworkflow_event;


  create or replace pipe customer_pipe
  auto_ingest = true
  integration = 'ETLWORKFLOW_EVENT'
  as
  copy into landing_customer from @delta_customer_azure
  file_format = fileformat_azure
  --PATTERN='customer_history_6.csv';
  --pattern='.*customer.*[.]csv';
  pattern='*\\.csv'


  select $1 from @delta_customer_azure

create or replace pipe item_pipe
  auto_ingest = true
  integration = 'ETLWORKFLOW_EVENT'
  as
  copy into landing_item from @delta_items_azure
  file_format = fileformat_azure
  pattern='.*item.*[.]csv';

create or replace pipe order_pipe
  auto_ingest = true
  integration = 'ETLWORKFLOW_EVENT'
  as
  copy into landing_order from @delta_orders_azure
  file_format = fileformat_azure
  pattern='.*order.*[.]csv';


  
DROP PIPE IF EXISTS customer_pipe;
DROP PIPE IF EXISTS item_pipe;
DROP PIPE IF EXISTS order_pipe;

truncate table landing_customer
  

select system$pipe_status('customer_pipe')
select system$pipe_status('item_pipe')
select system$pipe_status('order_pipe')



//  select data from table 
select * from landing_customer;
select * from landing_item;
select * from landing_order;

truncate landing_order




select * from table(validate_pipe_load(
  pipe_name=>'customer_pipe',
  start_time=>dateadd(hour, -1, current_timestamp())));

desc pipe customer_pipe
show pipes
select system$pipe_status('customer_pipe')


  
  
SELECT *
FROM TABLE( PROJECTETLWORKFLOW.LANDING_ZONE.PIPE_HISTORY());