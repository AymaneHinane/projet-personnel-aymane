
import React from 'react'

const Toto = ({name,leState,reponse}) => {

    const btn=leState.messageMaman?(<button onClick={reponse}>Reponse</button>):(<button disabled>Reponse</button>);
   

    return(
        <div>
            <p>je suis {name}</p>
            {btn}
            <p>{leState.messageToto}</p>
        </div>
    )
}

export default Toto;