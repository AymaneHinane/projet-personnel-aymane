use schema PROJECTETLWORKFLOW.LANDING_ZONE;


create or replace stream landing_item_stm on table landing_item
append_only = true;

create or replace stream landing_customer_stm on table landing_customer
append_only = true;

create or replace stream landing_order_stm on table landing_order
append_only = true;

show streams;

-------------------------------------------

 use schema PROJECTETLWORKFLOW.CURATED_ZONE;


CREATE OR REPLACE TASK order_curated_tsk
  WAREHOUSE = compute_wh
  SCHEDULE = '1 minute'
WHEN
  system$stream_has_data('PROJECTETLWORKFLOW.LANDING_ZONE.landing_order_stm')
AS
  MERGE INTO PROJECTETLWORKFLOW.CURATED_ZONE.curated_order AS curated_order
  USING PROJECTETLWORKFLOW.LANDING_ZONE.landing_order_stm AS landing_order_stm
  ON
    curated_order.order_date = landing_order_stm.order_date AND
    curated_order.order_time = landing_order_stm.order_time AND
    curated_order.item_id = landing_order_stm.item_id AND
    curated_order.item_desc = landing_order_stm.item_desc
WHEN MATCHED THEN
  UPDATE SET
    curated_order.customer_id = landing_order_stm.customer_id,
    curated_order.salutation = landing_order_stm.salutation,
    curated_order.first_name = landing_order_stm.first_name,
    curated_order.last_name = landing_order_stm.last_name,
    curated_order.store_id = landing_order_stm.store_id,
    curated_order.store_name = landing_order_stm.store_name,
    curated_order.order_quantity = landing_order_stm.order_quantity,
    curated_order.sale_price = landing_order_stm.sale_price,
    curated_order.disount_amt = landing_order_stm.disount_amt,  
    curated_order.coupon_amt = landing_order_stm.coupon_amt, 
    curated_order.net_paid = landing_order_stm.net_paid,
    curated_order.net_paid_tax = landing_order_stm.net_paid_tax,
    curated_order.net_profit = landing_order_stm.net_profit
WHEN NOT MATCHED THEN
  INSERT (
    ORDER_DATE,
    ORDER_TIME,
    ITEM_ID, 
    ITEM_DESC, 
    CUSTOMER_ID,
    SALUTATION,
    FIRST_NAME, 
    LAST_NAME,
    STORE_ID, 
    STORE_NAME, 
    ORDER_QUANTITY, 
    SALE_PRICE, 
    DISOUNT_AMT, 
    COUPON_AMT, 
    NET_PAID, 
    NET_PAID_TAX, 
    NET_PROFIT
  ) 
  VALUES (
    landing_order_stm.ORDER_DATE, 
    landing_order_stm.ORDER_TIME, 
    landing_order_stm.ITEM_ID, 
    landing_order_stm.ITEM_DESC, 
    landing_order_stm.CUSTOMER_ID, 
    landing_order_stm.SALUTATION, 
    landing_order_stm.FIRST_NAME, 
    landing_order_stm.LAST_NAME, 
    landing_order_stm.STORE_ID, 
    landing_order_stm.STORE_NAME, 
    landing_order_stm.ORDER_QUANTITY, 
    landing_order_stm.SALE_PRICE, 
    landing_order_stm.DISOUNT_AMT, 
    landing_order_stm.COUPON_AMT, 
    landing_order_stm.NET_PAID, 
    landing_order_stm.NET_PAID_TAX, 
    landing_order_stm.NET_PROFIT
  );

------------------------------------

create or replace task customer_curated_tsk
  warehouse = compute_wh
  schedule = '2 minute'
when 
  system$stream_has_data('PROJECTETLWORKFLOW.LANDING_ZONE.landing_customer_stm')
as
merge into PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_CUSTOMER curated_customer
using PROJECTETLWORKFLOW.LANDING_ZONE.landing_customer_stm landing_customer_stm on
curated_customer.customer_id = landing_customer_stm.customer_id 
when matched
  then update set
     curated_customer.salutation = landing_customer_stm.salutation,
     curated_customer.first_name = landing_customer_stm.first_name,
     curated_customer.last_name = landing_customer_stm.last_name,
     curated_customer.birth_day = landing_customer_stm.birth_day,
     curated_customer.birth_month = landing_customer_stm.birth_month,
     curated_customer.birth_year = landing_customer_stm.birth_year,
     curated_customer.birth_country = landing_customer_stm.birth_country,
     curated_customer.email_address = landing_customer_stm.email_address
when not matched then
insert(
CUSTOMER_ID,
SALUTATION,
FIRST_NAME,
LAST_NAME,
BIRTH_DAY,
BIRTH_MONTH,
BIRTH_YEAR,
BIRTH_COUNTRY,
EMAIL_ADDRESS
)values(
landing_customer_stm.CUSTOMER_ID,
landing_customer_stm.SALUTATION,
landing_customer_stm.FIRST_NAME,
landing_customer_stm.LAST_NAME,
landing_customer_stm.BIRTH_DAY,
landing_customer_stm.BIRTH_MONTH,
landing_customer_stm.BIRTH_YEAR,
landing_customer_stm.BIRTH_COUNTRY,
landing_customer_stm.EMAIL_ADDRESS
);

----------------------------------

create or replace task item_curated_tsk
  warehouse = compute_wh
  schedule = '3 minute'
when
  system$stream_has_data('PROJECTETLWORKFLOW.LANDING_ZONE.landing_item_stm')  
as
merge into PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ITEM item 
using PROJECTETLWORKFLOW.LANDING_ZONE.landing_item_stm landing_item_stm
on
item.item_id = landing_item_stm.item_id and
item.item_desc = landing_item_stm.item_desc and
item.start_date = landing_item_stm.start_date 
when matched
  then update set
    item.end_date = landing_item_stm.end_date,
    item.price = landing_item_stm.price,
    item.item_class = landing_item_stm.item_class,
    item.item_category = landing_item_stm.item_category
when not matched then
insert(
ITEM_ID,
ITEM_DESC,
START_DATE,
END_DATE,
PRICE,
ITEM_CLASS,
ITEM_CATEGORY
) values (
landing_item_stm.ITEM_ID,
ITEM_DESC,
landing_item_stm.START_DATE,
landing_item_stm.END_DATE,
landing_item_stm.PRICE,
landing_item_stm.ITEM_CLASS,
landing_item_stm.ITEM_CATEGORY
);

show tasks;

--lets resume this task so they start running
alter task order_curated_tsk resume;
alter task customer_curated_tsk resume;
alter task item_curated_tsk resume;


--lets see the status via task history
select * from table(information_schema.task_history())
  where name in ('CUSTOMER_CURATED_TSK','ITEM_CURATED_TSK','ORDER_CURATED_TSK')
  order by scheduled_time;

