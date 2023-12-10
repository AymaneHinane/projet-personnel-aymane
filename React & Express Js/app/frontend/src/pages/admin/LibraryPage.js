import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom';

export default function LibraryPage() {

  const [library, setLibrary] = useState('');
  const [bookstores,setBookstores] = useState();


  useEffect(() => {

    getbookstores();

  }, [])



  const getbookstores = async () => {
    var {data} = await axios.get("/library")
    console.log(data);
    setBookstores(data)
}

  const AddLibrary = async () => {
      await axios.post("/library", { name: library })
      getbookstores();
  }


  return bookstores &&  (
    <div>
    <input className="form-control" type="text" placeholder="Default input" aria-label="default input example" value={library} onChange={e => setLibrary(e.target.value)} />
    <p> </p>
    <button onClick={AddLibrary}>Add new Library</button>
    <table className="table">
        <thead>
            <tr>
                <th></th>
                <th>id</th>
                <th>name</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            {bookstores.map((store, index) => {
                return (

                    <tr key={index}>
                        <td><Link to={`/admin/library/info/${store._id}`}> <button>consulter</button></Link> </td>
                        <td>{store._id}</td>
                        <td>{store.name}</td>
                        <td><Link to={`/admin/library/add/${store._id}`}><button type="button" className="btn btn-primary">Add Product</button></Link></td>
                    </tr>
                )
            })}
        </tbody>
    </table>
</div>
  )
}
