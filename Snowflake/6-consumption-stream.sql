use schema PROJECTETLWORKFLOW.curated_zone;

create or replace stream curated_item_stm on table curated_item;
create or replace stream curated_customer_stm on table curated_customer;
create or replace stream curated_order_stm on table curated_order;

use schema PROJECTETLWORKFLOW.CONSUMPTION_ZONE;


show streams;

-------------------------------------------------

use schema PROJECTETLWORKFLOW.CONSUMPTION_ZONE;

create or replace task item_consumption_tsk
  warehouse = compute_wh
  schedule = '4 minute'
when 
  system$stream_has_data('ch19.curated_zone.curated_item_stm')
as
 merge into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_DIM as item using PROJECTETLWORKFLOW.curated_zone.curated_item_stm as curated_item_stm on
 item.item_id = curated_item_stm.item_id and 
 item.start_date = curated_item_stm.start_date and
 item.item_desc = curated_item_stm.item_desc 
when matched
  and curated_item_stm.METADATA$ACTION = 'INSERT'
  and curated_item_stm.MEDATADA$ISUPDATED = 'TRUE'
  then update set
    item.end_date = curated_item_stm.end_date,
    item.price = curated_item_stm.price,
    item.item_class = curated_item_stm.item_class,
    item.item_category = curated_item_stm.item_category
when matched
 and curated_item_stm.METADATA$ACTION = 'DELETE'
 and curated_item_stm.METADATA$ISUPDATE = 'FLASE'
 then update set
   item.active_flag = 'N',
   item.updated_timestamp = current_timestamp()
when not matched
  and curated_item_stm.METADATA$ACTION = 'INSERT'
  and curated_item_stm.METADATA$ISUPDATED = 'FALSE'
then 
 insert(
  ITEM_ID, 
  ITEM_DESC, 
  START_DATE,
  END_DATE,
  PRICE,
  ITEM_CLASS,
  ITEM_CATEGORY,
  ADDED_TIMESTAMP,
  UPDATED_TIMESTAMP,
  ACTIVE_FLAG
 )
 values(
   curated_item_stm.ITEM_ID, 
   curated_item_stm.ITEM_DESC, 
   curated_item_stm.START_DATE,
   curated_item_stm.END_DATE,
   curated_item_stm.PRICE,
   curated_item_stm.ITEM_CLASS,
   curated_item_stm.ITEM_CATEGORY,
   curated_item_stm.ADDED_TIMESTAMP,
   curated_item_stm.UPDATED_TIMESTAMP,
   curated_item_stm.ACTIVE_FLAG
 );

-------------------------------------------------


create or replace task customer_consumption_task
  warehouse = compute_wh
schedule = '5 minute'
when
  system$stream_has_data('PROJECTETLWORKFLOW.curated_zone.curated_customer_stm')
as
  merge into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.customer_dim as customer using
  PROJECTETLWORKFLOW.curated_zone.curated_customer_stm as curated_customer_stm on
  customer.customer_id = curated_customer_stm.customer_id
when matched
 and curated_customer_stm.METADA$ACTION = 'INSERT'
 and curated_customer_stm.METADATA$ISUPDATE = 'TRUE'
 then update set
     customer.salutation = curated_customer_stm.salutation,
     customer.first_name = curated_customer_stm.first_name,
     customer.last_name = curated_customer_stm.last_name,
     customer.birth_day = curated_customer_stm.birth_day,
     customer.birth_month = curated_customer_stm.birth_month,
     customer.birth_year = curated_customer_stm.birth_year,
     customer.birth_country = curated_customer_stm.birth_country,
     customer.email_address = curated_customer_stm.email_address
when matched
  and curated_customer_stm.METADATA$ACTION = 'DELETE'
  and curated_customer_stm.METADATA$ISUPDATE = 'FALSE'
  then update set
     item.active_flag = 'N',
     item.updated_timestamp = current_timestamp()
when not matched
   and curated_customer_stm.METADATA$ACTION = 'INSERT'
   and curated_customer_stm.METADATA$ISUPDATE = 'FALSE' 
then 
  insert (
CUSTOMER_ID,
SALUTATION,
FIRST_NAME,
LAST_NAME,
BIRTH_DAY, 
BIRTH_MONTH,
BIRTH_YEAR, 
BIRTH_COUNTRY,
EMAIL_ADDRESS
) values(
curated_customer_stm.CUSTOMER_ID,
curated_customer_stm.SALUTATION,
curated_customer_stm.FIRST_NAME,
curated_customer_stm.LAST_NAME,
curated_customer_stm.BIRTH_DAY, 
curated_customer_stm.BIRTH_MONTH,
curated_customer_stm.BIRTH_YEAR, 
curated_customer_stm.BIRTH_COUNTRY,
curated_customer_stm.EMAIL_ADDRESS
);
    
----------------------------------

create or replace task order_fact_tsk
warehouse = compute_wh
schedule = '6 minute'
when
  system$stream_has_data('PROJECTETLWORKFLOW.curated_zone.curated_order_stm')
as
insert into PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ORDER_FACT(
ORDER_DATE, CUSTOMER_DIM_KEY, ITEM_DIM_KEY,ORDER_COUNT, ORDER_QUANTITY, SALE_PRICE, DISOUNT_AMT, COUPON_AMT, NET_PAID, NET_PAID_TAX, NET_PROFIT
)
select 
 co.order_date, 
 cd.customer_dim_key,
 id.item_dim_key,
 count(1) as order_count,
 sum(co.order_quantity),
 sum(co.sale_price),
 sum(co.disount_amt),
 sum(co.coupon_amt),
 sum(co.net_paid),
 sum(co.net_paid_tax),
 sum(co.net_profit)  
from  PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ORDER co
join  PROJECTETLWORKFLOW.CONSUMPTION_ZONE.CUSTOMER_DIM cd on cd.customer_id = co.customer_id 
join  PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_DIM id on id.item_id = co.item_id and id.item_desc = co.item_desc and id.end_date is null
group by
  co.order_date,
  cd.customer_dim_key,
  id.item_dim_key 
order by co.order_date;


alter task item_consumption_tsk resume;
alter task customer_consumption_task resume;
alter task order_fact_tsk resume;


select * from table(information_schema.task_history())
  where name in ('PROJECTETLWORKFLOW.CONSUMPTION_ZONE.CUSTOMER_CONSUMPTION_TASK','PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ITEM_CONSUMPTION_TSK','PROJECTETLWORKFLOW.CONSUMPTION_ZONE.ORDER_FACT_TSK')
  order by scheduled_time;
