import React, { useState, useEffect } from 'react'
import axios from 'axios'
import removeUploadedFiles from 'multer/lib/remove-uploaded-files'
import { Link } from 'react-router-dom';

export default function ProductAdminPage() {

  const Filter = {
    name:'',
    category:'',
  }

  const [products, setProduct] = useState();
  const [filter,setFilter] = useState(Filter);
  const [category,setCategory] = useState();
  const [succes, setSucces] = useState()
  const [failed,setFailed] = useState()
  const [error,setError] = useState()

  const isSucces = ()=>{
      setSucces(true);
      setFailed(false);
  }

  const isFailed = () =>{
      setSucces(false);
      setFailed(true);
  }



  useEffect(() => {
    getCategory();
    getProducts();
    
  }, [])

  // useEffect(() => {

  //   console.log(products);
  // }, [products])

  const getProducts = () => {

    axios.get('/product').then((response) => {
      setProduct(response.data)
    }).catch(err => {
      // alert("you are not authorized ProductAminPage.js") 
    })
  }

  const deleteProduct = (id) => {
    axios.delete(`/product/${id}`).then((response) => {
      getProducts()
      isSucces()
    }).catch(err => {
      //alert("you are not authorized ProductAminPage.js")
      setError(err.response.data.err)
      isFailed()
      
      console.log(err.response.data.err);
    })
  }

  const searchProduct = (e)=>{
     e.preventDefault();
     axios.get(`/product/filter?name=${filter.name}&category=${filter.category}`)
     .then(response => {
         setProduct(response.data);
         console.log(response.data);
        
     }).catch(err => {

     })
  }

  function getCategory()
  {
       axios.get('/product/category')
       .then(response=>{
             setCategory(response.data);
       }).catch(err=>{

       })
  }

  return products&& (

    <div>
       {succes &&
                <div className="alert alert-success" role="alert">
                    A simple success alert—check it out!
                </div> }

           { failed &&<div className="alert alert-danger" role="alert">
                    A simple danger alert—check it out!
                </div>
            }
      {category &&
      <div className=" accordion " id="accordionFlushExample" style={{paddingBottom:50}}>
        <div className="accordion-item">
          <h2 className="accordion-header" id="flush-headingOne">
            <button className="accordion-button collapsed " type="button" data-bs-toggle="collapse" data-bs-target="#flush-collapseOne" aria-expanded="false" 
            aria-controls="flush-collapseOne" >
               Filter Product
            </button>
          </h2>
          <div id="flush-collapseOne" className="accordion-collapse collapse" aria-labelledby="flush-headingOne" data-bs-parent="#accordionFlushExample">
            <div className="accordion-body">
                 <div className='container'>
                     <div className='row'>
                        <div className='col-4'>
                           <input className="form-control" type="text" placeholder="search by name" aria-label="default input example" name='name'
                            value={filter.name} onChange={e=>setFilter({...filter,[e.target.name]:e.target.value})}/>
                        </div>
                        <div className='col-4'>
                        <select  className="form-select " aria-label="Default select example" name='category' value={filter.category} 
                        onChange={e=>setFilter({...filter,[e.target.name]:e.target.value})}>
                        <option value='' >Open this select menu</option>
                        {category.map((cat,key)=>{
                           return <option key={key} value={cat.name}>{cat.name}</option>
                        })}
                    </select>
                        </div>
                        <div className='col-2'>
                           <button type="button" className="btn btn-primary" onClick={searchProduct}>Primary</button>
                         </div>
                     </div>
                 </div>
              </div>
          </div>
        </div>
      </div>
     }

      <Link to={'/admin/product/add'}> <button>Add new Product</button></Link>
      <table className="table">
        <thead>
          <tr>
            <th></th>
            <th>name</th>
            <th>description</th>
            <th>category</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {products.map((product, index) => {
            return (

              <tr key={index}>
                 <td> <Link to={`/admin/product/info/${product._id}`}> <button>consulter</button></Link></td>
                <td>{product.name}</td>
                <td>{product.description}</td>
                <td>{product.category.name}</td>
                <td><button onClick={() => deleteProduct(product._id)}>Supprimer</button></td>
                <td><Link to={`/admin/product/update/${product._id}`}> <button>Modifier</button></Link></td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}
