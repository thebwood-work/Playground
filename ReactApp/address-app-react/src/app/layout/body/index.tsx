import { Container } from "@mui/material";


 function Body({children}: {children:HTMLElement}) {
    return (
        <Container>
            {children}
        </Container>
    );
};
export default Body;