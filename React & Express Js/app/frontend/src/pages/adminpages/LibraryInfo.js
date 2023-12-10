import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { Link } from 'react-router-dom';

export default function LibraryInfo() {

  const params = useParams();
  const [products,setProduct] = useState();
  const [quantite,setQuantite] = useState(); 

  useEffect(()=>{
    getProducts();
  },[])

  const getProducts = ()=>{
    axios.get(`/library/${params.id}/product`)
    .then(response=>{
       setProduct(response.data);
    })
    .catch()
  }

  const UpdateQuantity = (id)=>{
      axios.put(`/library/${params.id}`,{product:id,quantite:quantite})
      .then(response =>{
        alert("update successfuly")
      })
      .catch(err=>{})
  }

  const deleteProduct = (id)=>{
    axios.delete(`/library/${params.id}/product/${id}`)
    .then(response =>{
      alert("update successfuly")
      getProducts();
    })
    .catch(err=>{})
}

  return products && (
    <div>
       <table className="table">
        <thead>
          <tr>
            <th></th>
            <th>name</th>
            <th>description</th>
            <th>category</th>
            <th>quantite</th>
            <th>New quantite</th>
            <th></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {products.map((product, index) => {
            return (

              <tr key={index}>
                 <td> <Link to={`/admin/product/info/${product.product._id}`}> <button>consulter</button></Link></td>
                <td>{product.product.name}</td>
                <td>{product.product.description}</td>
                <td>{product.product.category.name}</td>
                <td>{product.quantite}</td>
                <td>
                <input class="form-control form-control-sm"
                      type="text" placeholder="" aria-label=".form-control-sm example"  onChange={(e)=>setQuantite(e.target.value)} />
                </td>
                <td><button onClick={()=>UpdateQuantity(product.product._id)}>Modifier</button></td> 
                <td><button onClick={()=>deleteProduct(product.product._id)}>Supprimer</button></td> 
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}
