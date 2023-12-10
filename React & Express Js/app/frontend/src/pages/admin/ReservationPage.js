import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom';


export default function ReservationPage() {

  const [reservation,setReservation] = useState();


   useEffect(()=>{
     getReservation();
   },[])

   useEffect(()=>{
       console.log(reservation);
   },[reservation])

   const getReservation = ()=>{
      axios.get('/reservation').then(({data})=>{
          setReservation(data)
      }).catch(err=>{

      })
   }

   const deleteReservation  = (id)=>{
      axios.delete(`/reservation/${id}`)
       .then(({data})=>{
          getReservation()
       }).catch(err=>{})
   }

  return reservation &&(
    <div>
      <table className="table">
      <thead>
                    <tr>
                        <th>name</th>
                        <th>date de reservation</th>
                        <th>date  rendu</th>
                        <th>product name</th>
                        <th>pris</th>
                        <th>rendue</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    { reservation.map((res, index) => {
                        return (

                            <tr key={index}>
                                <td>{res.user.name}</td>
                                <td>{res.reservationDate}</td>
                                <td>{res.renderDate}</td>
                                <td>{res.product && res.product.name}</td>
                                <td>{String(res.took)}</td>
                                <td>{String(res.return)}</td>
                                <td>
                                  <button className="btn btn-success" onClick={()=>deleteReservation(res._id)}>delete</button> 
                                </td>
                                <td>
                                    <Link to={`/admin/reservation/update/${res._id}`}><button className="btn btn-success">modifier</button> </Link>
                                </td>

                                </tr>
                        )
                    })} 
                </tbody>
                </table>
    </div>
  )


}

