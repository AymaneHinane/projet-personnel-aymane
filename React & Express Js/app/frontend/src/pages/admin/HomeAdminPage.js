import React, { useState, useEffect, useContext } from 'react'
import { UserContext } from '../../UserContext'
import axios from 'axios'


export default function HomeAdminPage() {

  const { user } = useContext(UserContext);
  const [customers, setCustomer] = useState([]);
  const [succes, setSucces] = useState()
  const [failed,setFailed] = useState()


  const isSucces = ()=>{
      setSucces(true);
      setFailed(false);
  }

  const isFailed = () =>{
      setSucces(false);
      setFailed(true);
  }

 // console.log(user.roles[0]);


  useEffect(() => {

    getCustomers();
  }, [])

  const getCustomers = () => {

    axios.get('/customer').then((response) => {
      setCustomer(response.data)
    }).catch(err => {
      // alert("you are not authorized ProductAminPage.js") 
    })
  }


  const ChangeRole = (id,role)=>{
    
    const newRole = role == 'user' ? 'employee': 'user'

     axios.put(`/customer/role/${id}`,{roles:[newRole]})
     .then( ({data})=>{
        isSucces()
        getCustomers();
     }).catch(err=>{
        isFailed()
     })
  }


  return customers && (
    <div className='container'>

    <div className='row'>
      <div className='col-12'>
          {succes &&
                <div className="alert alert-success" role="alert">
                    le role a etait changer avec succee
                </div> }

           { failed &&<div className="alert alert-danger" role="alert">
                    vous ne pouvez pas changer le role pour se user
                </div>
            }

      </div>

      <div className='col-9'>
      <table className="table">
        <thead>
          <tr>
            <th>Full Name</th>
            <th>email</th>
            <th>role</th>
          </tr>
        </thead>
        <tbody>
          {customers.map((customer, index) => {
            return (
              <tr key={index}>
                <td>{customer.name}</td>
                <td>{customer.email}</td>
                <td>{customer.roles[0]}</td>
                <td><button onClick={()=>ChangeRole(customer._id,customer.roles[0])}>changer le role</button></td>
              </tr>
            )
          })}
        </tbody>
      </table>
      </div>


      </div>
    </div>
  )
}
