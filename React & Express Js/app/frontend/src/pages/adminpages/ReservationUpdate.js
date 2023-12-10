import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';



export default function ReservationUpdate() {

  const params = useParams();
  const [reservation,setReservation] = useState();
  const [data,setData] = useState();


  useEffect(()=>{
    getReservation();
  },[])



   useEffect(()=>{
    axios.put(`/reservation/${params.id}`,data).then(({data})=>{
      setReservation(data);
      getReservation();
     }).catch(err=>{

     })
   },[data])

  const getReservation = ()=>{
     axios.get(`/reservation/${params.id}`).then(({data})=>{
        setReservation(data);
     }).catch(err=>{

     })
  }


  return reservation && (
    <div className='container'>

       <div className='row'>
        <div className='cl-12'>
          <h4>user name: {reservation.user.name}</h4>

        </div>
        <div className='cl-12'>
          <h4>livre: {reservation.product.name}</h4>
        </div>
        <div className='cl-12'>
          <h4>date de reservation: {reservation.reservationDate}</h4>
        </div>
        <div className='cl-12'>
          <h4>date rendu: {reservation.renderDate}</h4>
        </div>
        <div className='cl-12'>
          {!reservation.took && <button type="button" class="btn btn-primary" onClick={()=>setData({took:true,takeDate:new Date()})}>Livre Donner</button>}
          {reservation.took && <button type="button" class="btn btn-success" style={{marginLeft:20,RenderAfterTake:new Date()}} onClick={()=>setData({return:true,RenderAfterTake:new Date()})}>Livre Rendu</button>} 
        </div>
        </div>
    </div>
  )
}
