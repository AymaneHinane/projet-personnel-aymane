import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';


export default function CustomerUpdate() {


    var NewCustomer = {
        name:"",
        email: "",
        phone:"",
    }

    const params = useParams();
    const [customer, setCustomer] = useState(NewCustomer);
    
    const [dataGet, setDataGet] = useState(false)
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




    const getCustomer = () => {

        axios.get(`/customer/${params.id}`).then(response => {     
            setCustomer(response.data)
            setDataGet(true)
        }).catch(err => {
            // alert("you are not authorized")
        })
    }


    useEffect(() => {
        getCustomer(params)
        // console.log(product);
    }, [])



    function AddProduct(name, value) {
        setCustomer({ ...customer, [name]: value })
    }

    function UpdateCustomer(e) {
        e.preventDefault();

        axios.put(`/customer/${params.id}`, customer)
            .then(response => {
               isSucces()
            }).catch(err => {
               isFailed()
            })
    }


    return dataGet && (
        <div className="container-fluid border-red">
            ProductUpdate

            {succes &&
                <div class="alert alert-success" role="alert">
                    A simple success alert—check it out!
                </div> }

           { failed &&<div class="alert alert-danger" role="alert">
                    A simple danger alert—check it out!
                </div>
            }

            <form className="row border-red">


                <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">name</label>
                    <div className="col-sm-10">
                        <input type="name" className="form-control" value={customer.name} onChange={(e) => AddProduct("name", e.target.value)} />
                    </div>
                </div>

            

                <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">email</label>
                    <div className="col-sm-10">
                        <input type="name" className="form-control" value={customer.email} onChange={(e) => AddProduct("email", e.target.value)} />
                    </div>
                </div>

                <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">phone</label>
                    <div className="col-sm-10">
                        <input type="name" className="form-control" value={customer.phone} onChange={(e) => AddProduct("phone", e.target.value)} />
                    </div>
                </div>



                
                <div className="mb-3 row">
                    <button className='col-lg-3' onClick={UpdateCustomer}>Save Modification</button>
                </div>
            </form>

    
        </div>
    )
}
