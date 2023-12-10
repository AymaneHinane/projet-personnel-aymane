import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';
// import { imagefrombuffer } from 'imagefrombuffer';


export default function ProductInfo() {

  const params = useParams();
  const [product, setProduct] = useState();
 // const [img, setImage] = useState([])


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

      setProduct({ ...response.data, images: tab })

    }).catch(err => {
      // alert("you are not authorized")
    })
  }

  useEffect(() => {

    getProducts();

  }, [])


  return product && (


    <div className='container'>

      <div className='row'>

        <>
          <div className='col-12'>
            <h2>Title</h2>
            <p>{product.name}</p>
          </div>
          <div className='col-12'>
            <h2>Overview</h2>
            <p>{product.description}</p>
          </div>
        </>

      </div>

      <div className='row' >
        {
          product.images.map(image => {

            return (<div className='col-3 '  style={{height:400,overflow:'hidden'}}>
              <img src={image} width="100%" />
            </div>)
          })
        }
      </div>

    </div>


  )
}
