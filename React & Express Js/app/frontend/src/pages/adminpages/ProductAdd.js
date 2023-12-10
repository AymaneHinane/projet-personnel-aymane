import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';


export default function ProductAdd() {

    var NewProduct = {
        name: "",
        description: "",
        // price: "",
        // quantite: "",
        category:''
    }
    const [product, setProduct] = useState(NewProduct);
    const [category,setCategory] = useState();

    useEffect(()=>{
        getCategory();
        
    },[])



    const submit = async (e) => {
        e.preventDefault();
        console.log(NewProduct);

        // if (isNaN(product.price)) {
        //     alert('price shoul be number')
        //     return
        // }

        var productAdded = await axios.post('/product', product)
       // console.log(productAdded);
    }

    function AddProduct(name, value) {

        if(name == 'category')
            value = category[value]._id

        setProduct({ ...product, [name]: value })
    }

    function getCategory()
    {
         axios.get('/product/category')
         .then(response=>{
               setCategory(response.data);
         }).catch(err=>{

         })
    }


    return category && (
        <div className="container-fluid ">
            <h2 style={{marginBottom:80}}>Add New Book</h2>

            <form className="row " onSubmit={submit}>
                <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">name</label>
                    <div className="col-sm-10">
                        <input type="name" className="form-control" value={product.name} onChange={(e) => AddProduct("name", e.target.value)} />
                    </div>
                </div>
                <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">description</label>
                    <div className="col-sm-10">
                        <input type="description" className="form-control" value={product.description} onChange={(e) => AddProduct("description", e.target.value)} />
                    </div>
                </div>
                {/* <div className="mb-3 row">
                    <label className="col-sm-2 col-form-label">quantite</label>
                    <div className="col-sm-10">
                        <input type="description" className="form-control" value={product.quantite} onChange={(e) => AddProduct("quantite", e.target.value)} />
                    </div>
                </div> */}
                <div className="mb-3 row">
                <label className="col-sm-2 col-form-label">Category</label>
                  <div className='col-sm-10'>
                    <select  className="form-select " aria-label="Default select example" onChange={(e) => AddProduct("category", e.target.value)}>
                        <option selected>Open this select menu</option>
                        {category.map((cat,key)=>{
                           return <option value={key}>{cat.name}</option>
                        })}
                    </select>
                   </div>
                </div>
                {/* <div className="input-group mb-3">
                    <label className="col-sm-2 col-form-label">price</label>
                    <span className="input-group-text">$</span>
                    <input type="price" className="form-control" aria-label="Amount (to the nearest dollar)" value={product.price} onChange={(e) => AddProduct("price", e.target.value)} />
                    <span className="input-group-text">.00</span>
                </div> */}

                <div>
                    <button>Submit</button>
                </div>

            </form>
        </div>
    )
}
