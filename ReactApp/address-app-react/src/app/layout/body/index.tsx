import { Container } from "@mui/material";
import { FC } from "react";


 function Body({children}: {children:any}) {
    return (
        <Container>
            {children}
        </Container>
    );
};
export default Body;