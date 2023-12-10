import React, { useState, useEffect,useContext } from 'react'
import axios from 'axios'
import { UserContext } from '../UserContext'
import { Link } from 'react-router-dom';

export default function BookStore() {

    const Filter = {
        name: '',
        category: '',
    }

    const [products, setProduct] = useState([]);
    const [filter, setFilter] = useState(Filter);
   // const [category, setCategory] = useState();
    const [succes, setSucces] = useState()
    const [failed,setFailed] = useState()
    const [errorMsg,setError] = useState();

    const { user, setUser,setConnect } = useContext(UserContext)
    const {connect,Setconnect} = useState(user)
    
    console.log(user);


    const isSucces = ()=>{
        setSucces(true);
        setFailed(false);
    }

    const isFailed = () =>{
        setSucces(false);
        setFailed(true);
    }

    useEffect(() => {
        
        setConnect(true)
        getProducts();
        //getCategory();
    }, [])


    const getProducts = () => {

        axios.get('/library/BookStore').then((response) => {
            setProduct(response.data)
            console.log(response.data);
            setConnect(true)
        }).catch(err => {
        })
    }

    // function getCategory() {

    //     axios.get('/library/BookStore')
    //         .then(response => {
    //             setCategory(response.data);
    //         }).catch(err => {

    //         })
    // }

    function arrayBufferToBase64(buffer) {
        var binary = '';
        var bytes = [].slice.call(new Uint8Array(buffer));
        bytes.forEach((b) => binary += String.fromCharCode(b));
        return window.btoa(binary);
    };

    function convertImg(image) {
        var base64Flag = `data:${image.img?.contentType};base64,`;
        var imageStr = arrayBufferToBase64(image.img?.data?.data);
        return base64Flag + imageStr
    }


    function ReserverBook(libraryId,productId){
         console.log(libraryId);
         console.log(productId);
         console.log(user)

         axios.post('/reservation',{user:user.id,product:productId,library:libraryId})
          .then(response=>{
             console.log(response.data);
             isSucces()
          }).catch(err=>{
            console.log(err.response.data);
            setError(err.response.data.err)
            isFailed();
          })

    }

    return products.length > 0 ? (
        <div className='container' style={{ marginTop: 50 }}>
            {succes &&
                <div class="alert alert-success" role="alert">
                    reservation accomplit avec scces !!!
                </div> }

           { failed &&<div class="alert alert-danger" role="alert">
                    {errorMsg}
                </div>
            }
            
            <div className='row row-cols-4 g-4'>
                {products.map((produit, key) => {
                    return (
                        <div className='col'>
                            <div key={key} class="card p-2" >
                                <img src={convertImg(produit.product.images.length > 0 && produit.product.images[0])} style={{ width: '100%', height: '400px' }} class="card-img-top" alt="..." />
                                <div className="card-body">
                                    <h5 className="card-title">{produit.product.name}</h5>
                                    <p className="card-text">category: {produit.product.category.name}</p>
                                    <p className="card-text">Library: {produit.library.name}</p>
                                    <a href="#" className="btn btn-primary" onClick={()=>ReserverBook(produit.library._id,produit.product._id)}>reserver</a>
                                </div>
                            </div>
                        </div>

                    )
                })}
            </div>
        </div>
    ) : (
        <div class="d-flex justify-content-center">
            <div class="spinner-border" role="status">
                <span class="visually-hidden">Loading...</span>
            </div>
        </div>
    )
}
