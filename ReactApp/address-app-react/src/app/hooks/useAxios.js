import { useState, useEffect } from 'react';
import axios from 'axios';

axios.defaults.baseURL = 'https://localhost:5010';


export const useAxios = (props) => {
    const [response, setResponse] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const executeRequest = async (params) => {
        setLoading(true);
        await axios.request(params)
                    .then(result => {
                      setResponse(result.data);
                      setError(null);
                    })
                    .catch(err => {
                      if (err.response.status === 404) {
                        setError(`${err.config.url} not found`);
                      }
                      else
                        setError(err.error);
                      })
                    .finally(() => {
                      setLoading(false);
                    });
    };
    
    useEffect(() => {
      executeRequest(params);
    }, []);
    
    return { response, error, loading };

};