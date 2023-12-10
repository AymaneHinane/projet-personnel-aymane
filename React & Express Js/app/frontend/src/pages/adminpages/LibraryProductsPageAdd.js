import React, { useState } from 'react'
import axios from 'axios';
import { useParams } from 'react-router-dom';
import { Link } from 'react-router-dom';


export default function LibraryProductsPageAdd() {

  const params = useParams();
  const [name, setName] = useState('');
  const [products, setProduct] = useState();
  const [quantite,setQuantite] = useState();

  // useEffect(() => {
  //   //console.log(name);
  // }, [name])


  // useEffect(() => {
  //   //console.log(products);
  // }, [products])


  const getProducts = async (e) => {
    e.preventDefault();

        axios.get(`/product/filter?name=${name}&category=`)
        .then(({data})=>{
           setProduct(data)
        }).catch(err=>{

        })
  }

  const AddProductToLibrary = async (e,id) => {
      e.preventDefault();


         axios.get(`/library/${params.id}/product/${id}`)
          .then( response =>{

              if(response.data)
              {
                alert("se produit existe deja")   
              }           
              else
              {
                axios.post(`/library/${params.id}`,{product:id,quantite:quantite})
              }


          })
          .catch(err => { })    
  }



  return  (

    <div className='container'>
      <div className='row'>


        <h2 className='col-12'>Rechercher le produit</h2>

        <form className="container  mb-5">
          <div className='row'>
            <div className=" col-6 ">
              {/* <label className="col-sm-2 col-form-label">name</label> */}
              <div >
                <input type="name" className="form-control" placeholder='enter product name' name='name'  onChange={(e) => setName(e.target.value)} />
              </div>
            </div>

            <button type="button" class="btn btn-success col-3" onClick={getProducts}>Search</button>
          </div>
        </form>

      </div>

      <table className="table">
        <thead>
          <tr>
            <th>name</th>
            <th>description</th>
            <th>category</th>
            <th>quantite</th>
            <th></th>
          </tr>
        </thead>

        {products &&
          <tbody>
            {products.map((product, index) => {
              return (

                <tr key={index}>
                  <td>{product.name}</td>
                  <td>{product.description}</td>
                  <td>{product.category.name}</td>
                  <td>
                    <input class="form-control form-control-sm"
                      type="text" placeholder="" aria-label=".form-control-sm example"  onChange={(e)=>setQuantite(e.target.value)} />
                  </td>
                  <td><button type="button" class="btn btn-primary"  onClick={(e)=>AddProductToLibrary(e,product._id)}>Add</button></td>
                </tr>
              )
            })}
          </tbody>
        }


      </table>


    </div>

  )
}
