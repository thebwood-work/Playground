import { Link, ListItem, ListItemIcon, ListItemText } from "@mui/material";
import React from "react";

export default function ListItemLink(props:any) {
    const { icon, primary, to } = props;
  
    return (
        <ListItem button component={Link} href={to} >
            {icon ? <ListItemIcon>{icon}</ListItemIcon> : null}
            <ListItemText primary={primary} />
        </ListItem>
    );
  }