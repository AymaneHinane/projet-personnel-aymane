import React, { useState, useEffect } from 'react'
import axios from 'axios'
import removeUploadedFiles from 'multer/lib/remove-uploaded-files'
import { Link } from 'react-router-dom';

export default function CustomerAdminPage() {
  const [customers, setCustomer] = useState([]);



  useEffect(() => {

    getCustomers();
  }, [])

  const getCustomers = ()=>{
     
    axios.get('/customer').then((response) => {
      setCustomer(response.data)
    }).catch(err => {
     // alert("you are not authorized ProductAminPage.js") 
    })
  }

  const deleteCustomer = (id)=>{
    axios.delete(`/customer/${id}`).then((response) => {     
      getCustomers()
    }).catch(err => {
      alert("you are not authorized ProductAminPage.js")
    })   
  }

return (

<div>

    <table className="table">             
                  <thead>               
                        <tr>
                          <th></th>
                         
                          <th>Full Name</th>
                          <th>email</th>
                          <th>phone</th>
            
                          <th></th>
                          <th></th>
                        </tr>
                    </thead>    
          <tbody>
            {customers.map((customer,index)=>{
                return (
                                         
                        <tr key={index}>
                          <td><Link to={`/admin/product/info/${customer._id}`}> <button>consulter</button></Link> </td> 
                         
                          <td>{customer.name}</td>
                          <td>{customer.email}</td>
                          <td>{customer.phone}</td>
                          {/* <td>{customer.address}</td> */}
                          <td><button onClick={()=>deleteCustomer(customer._id)}>Supprimer</button></td> 
                          <td><Link to={`/admin/customer/update/${customer._id}`}> <button>Modifier</button></Link></td>
                        </tr>                                
                )
            })}
         </tbody>
    </table>
</div>
  )
}
