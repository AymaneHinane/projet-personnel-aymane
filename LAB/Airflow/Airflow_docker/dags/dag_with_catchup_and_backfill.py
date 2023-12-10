from datetime import datetime, timedelta

from airflow import DAG
from airflow.operators.bash import BashOperator


default_args = {
    'owner': 'coder2j',
    'retries': 5,
    'retry_delay': timedelta(minutes=5)
}

with DAG(
    dag_id='dag_with_catchup_backfill_v08',
    default_args=default_args,
    start_date=datetime(2022, 10, 27),
    schedule_interval='@daily',
    catchup=False # don't execute etl in the past
    catchup=True # execute etl in the past
) as dag:
    task1 = BashOperator(
        task_id='task1',
        bash_command='echo This is a simple bash command!'
    )

    task1