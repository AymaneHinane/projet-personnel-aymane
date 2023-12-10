use schema PROJECTETLWORKFLOW.CURATED_ZONE;

create or replace transient table curated_customer (
    customer_pk number autoincrement,
    customer_id varchar(18),
    salutation varchar(18),
    first_name varchar(20),
    last_name varchar(30),
    birth_day number,
    birth_month number,
    birth_year number,
    birth_country varchar(20),
    email_address varchar(50)
) comment ='this is customer table with curated schema';


create or replace transient table curated_item (
        item_pk number autoincrement,
        item_id varchar(16),
        item_desc varchar,
        start_date date,
        end_date date,
        price number(7,2),
        item_class varchar(50),
        item_category varchar(50)
) comment ='this is item table with in curated schema';


create or replace transient table curated_order (
    order_pk number autoincrement,
    order_date date,
    order_time varchar,
    item_id varchar(16),
    item_desc varchar,
    customer_id varchar(18),
    salutation varchar(10),
    first_name varchar(20),
    last_name varchar(30),
    store_id varchar(16),
    store_name varchar(50),
    order_quantity number,
    sale_price number(7,2),
    disount_amt number(7,2),
    coupon_amt number(7,2),
    net_paid number(7,2),
    net_paid_tax number(7,2),
    net_profit number(7,2)
) comment ='this is order table with in curated schema';


show tables;

--moving data from landing zone to currated zone


insert into PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_CUSTOMER(
CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, BIRTH_DAY, BIRTH_MONTH, BIRTH_YEAR, BIRTH_COUNTRY, EMAIL_ADDRESS
)
select 
CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, BIRTH_DAY, BIRTH_MONTH, BIRTH_YEAR, BIRTH_COUNTRY, EMAIL_ADDRESS
from PROJECTETLWORKFLOW.LANDING_ZONE.LANDING_CUSTOMER;

select * from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_CUSTOMER;



insert into PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ITEM(
ITEM_ID, ITEM_DESC, START_DATE, END_DATE, PRICE, ITEM_CLASS, ITEM_CATEGORY
)
select ITEM_ID, ITEM_DESC, START_DATE, END_DATE, PRICE, ITEM_CLASS, ITEM_CATEGORY from PROJECTETLWORKFLOW.LANDING_ZONE.LANDING_ITEM;

select * from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ITEM


insert into PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ORDER(
ORDER_DATE, ORDER_TIME, ITEM_ID, ITEM_DESC, CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, STORE_ID, STORE_NAME, ORDER_QUANTITY, SALE_PRICE, DISOUNT_AMT, COUPON_AMT, NET_PAID, NET_PAID_TAX, NET_PROFIT
) 
select ORDER_DATE, ORDER_TIME, ITEM_ID, ITEM_DESC, CUSTOMER_ID, SALUTATION, FIRST_NAME, LAST_NAME, STORE_ID, STORE_NAME, ORDER_QUANTITY, SALE_PRICE, DISOUNT_AMT, COUPON_AMT, NET_PAID, NET_PAID_TAX, NET_PROFIT from PROJECTETLWORKFLOW.LANDING_ZONE.LANDING_ORDER;

select * from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ORDER


select * from PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_ORDER o
join PROJECTETLWORKFLOW.CURATED_ZONE.CURATED_CUSTOMER c where o.customer_id = c.customer_id

