import React from 'react'


const Count = ({count,children}) => {
const {value,btnColor}=count
     
console.log(children)
    return(
        <>
        
          <div className="bar-container">
            <h2 className="bar-pourcentage">{value} %</h2>
               <div className="bar-progressive" style={{width: `${value}%`,  backgroundColor:`${btnColor}`}}>
               </div>
          </div>
        </>
    )
}

export default React.memo(Count)