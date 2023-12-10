import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';

export default function ProductUpdate() {

    var NewProduct = {
        name: "",
        description: "",
        // price: "",
        // quantite: ""
    }

    const params = useParams();
    const [product, setProduct] = useState(NewProduct);
    const [selectedFile, setSelectedFile] = useState(null);
    const [images, setImages] = useState();
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

    function arrayBufferToBase64(buffer) {
        var binary = '';
        var bytes = [].slice.call(new Uint8Array(buffer));
        bytes.forEach((b) => binary += String.fromCharCode(b));
        return window.btoa(binary);
    };



    const getProducts = () => {

        axios.get(`/product/${params.id}`).then(response => {

            var tab = response.data.images.map(image => {
                var base64Flag = `data:${image.img?.contentType};base64,`;
                var imageStr = arrayBufferToBase64(image.img?.data?.data);
                return base64Flag + imageStr
            })
            setImages(tab);
            //setProduct({ ...response.data, images: tab })
            setProduct(response.data)
            setDataGet(true)
        }).catch(err => {
            // alert("you are not authorized")
        })
    }


    useEffect(() => {
        getProducts(params)
        // console.log(product);
    }, [])

    useEffect(() => {
        // console.log('ok')
        // console.log(product);
    }, [product])

    function AddProduct(name, value) {
        setProduct({ ...product, [name]: value })
    }

    const onFileChange = event => {
        setSelectedFile(event.target.files[0]);
    };

    const onFileUpload = (e) => {

        e.preventDefault();

        const formData = new FormData();

        formData.append(
            "image",
            selectedFile,
            selectedFile.name
        );
        formData.append(
            "product",
            params.id
        );

        // console.log(selectedFile);
        axios.post("/image", formData).then(response => {
            getProducts();

        }).catch(err => {
           
        })
    };

    function UpdateProduct(e) {
        e.preventDefault();

        const NewProduct = {...product}
        delete NewProduct.images;

        axios.put(`/product/${params.id}`, NewProduct)
            .then(response => {
               isSucces()
            }).catch(err => {
               isFailed()
            })
    }

    function DropImage(key) {

        const imgId = product.images[key]._id;
        const productId = product._id;

        axios.delete(`/product/image?idProduct=${productId}&idImage=${imgId}`)
            .then(response => {
                getProducts();
                isSucces()
            }).catch(err => {
                isFailed()
            })
    }


    return dataGet && (
        <div className="container-fluid" >
            <h2 style={{marginBottom:50}}> Update Product </h2>

            {succes &&
                <div className="alert alert-success" role="alert">
                    A simple success alert—check it out!
                </div> }

           { failed &&<div className="alert alert-danger" role="alert">
                    A simple danger alert—check it out!
                </div>
            }

            <form className="row ">
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
                <div className="mb-3 row">
                    <button className='col-lg-3' onClick={UpdateProduct}>Save Modification</button>
                </div>
            </form>

            <form className="row " onSubmit={onFileUpload}>
                <div className="mb-3">
                    <label for="formFile" className="form-label">Add picture</label>
                    <input className="form-control" type="file" id="formFile" onChange={onFileChange} />
                </div>
                <div className="mb-3 row">
                    <button className='col-lg-3' >Add image</button>
                </div>
            </form>

            {images && <div className='row' >
                {
                    images.map((image, key) => {

                        return (<div key={key} className='col-3 ' style={{ height: 400, overflow: 'hidden' }}>
                            <svg onClick={() => DropImage(key)} style={{ color: 'red' }} width={40} xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth={1.5} stroke="currentColor" className="w-6 h-6">
                                <path strokeLinecap="round" strokeLinejoin="round" d="M14.74 9l-.346 9m-4.788 0L9.26 9m9.968-3.21c.342.052.682.107 1.022.166m-1.022-.165L18.16 19.673a2.25 2.25 0 01-2.244 2.077H8.084a2.25 2.25 0 01-2.244-2.077L4.772 5.79m14.456 0a48.108 48.108 0 00-3.478-.397m-12 .562c.34-.059.68-.114 1.022-.165m0 0a48.11 48.11 0 013.478-.397m7.5 0v-.916c0-1.18-.91-2.164-2.09-2.201a51.964 51.964 0 00-3.32 0c-1.18.037-2.09 1.022-2.09 2.201v.916m7.5 0a48.667 48.667 0 00-7.5 0" />
                            </svg>


                            <img src={image} width="100%" alt='' />
                        </div>)
                    })
                }
            </div>
            }

        </div>
    )
}
