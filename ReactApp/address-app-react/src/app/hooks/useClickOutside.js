import React, { useEffect, useRef } from 'react';

function useClickOutside(elRef, callback) {
    const callbackRef = useRef();
    callbackRef.current = callback;
    useEffect(() => {
        const handleClickOutside = (e) => {
            if(!elRef?.current?.contains(e.target) && callbackRef)
                callbackRef.current(e);
        }
        document.addEventListener('click', handleClickOutside, true);
        return () => {
            document.removeEventListener('click', handleClickOutside, true);
        }
    }, [callbackRef, elRef]);
}

export default useClickOutside;