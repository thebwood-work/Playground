import React, { FC, Fragment } from "react";
import Body from "./body";
import Footer from "./footer";
import Header from "./header";
import './layout.scss';

function Layout({children}:{children:any}) {
    return (
        <Fragment>
            <Header />
            <Body>
                {children}
            </Body>
            <Footer />
        </Fragment>

    );
};

export default Layout;