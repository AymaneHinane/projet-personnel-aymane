import React, { useState, useEffect } from 'react'
import axios from 'axios'
import { Link } from 'react-router-dom';


export default function CategoryAdminPage() {

    const [category, setCategory] = useState('');
    const [categories, setCategories] = useState();

    useEffect(() => {

        getCategory();

    }, [])

    const getCategory = async () => {
        var {data} = await axios.get("/product/category")
        console.log(data);
        setCategories(data)
    }

    const AddCategory = async () => {
        await axios.post("/product/category", { name: category })
        await getCategory()
    }

    return  (

        <div>
            <input className="form-control" type="text" placeholder="Default input" aria-label="default input example" value={category} onChange={e => setCategory(e.target.value)} />
            <p> </p>
            <button onClick={AddCategory}>Add new Category</button>
            {categories &&( <table className="table">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>name</th>
                    </tr>
                </thead>
                <tbody>
                    {categories.map((cat, index) => {
                        return (

                            <tr key={index}>
                                <td>{cat._id}</td>
                                <td>{cat.name}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table> )}
        </div>
    )
}
