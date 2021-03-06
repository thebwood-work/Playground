import React, { Fragment } from 'react';
import { useTheme } from '@mui/material/styles';
import Drawer from '@mui/material/Drawer';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import ChevronRightIcon from '@mui/icons-material/ChevronRight';
import AppBar from '@mui/material/AppBar';
import { REACT_ROUTES } from '../../constants/constant';
import { ListItemButton, ListItemText } from '@mui/material';

const drawerWidth = 240;


export default function Header() {
  const theme = useTheme();
  const [open, setOpen] = React.useState(false);

  const handleDrawerOpen = () => {
    setOpen(true);
  };

  const handleDrawerClose = () => {
    setOpen(false);
  };

  return (
    <Fragment>
      <AppBar position="static">
        <Toolbar variant="dense">

          <IconButton
            color="inherit"
            aria-label="open drawer"
            onClick={handleDrawerOpen}
            edge="start"
            sx={{ mr: 2, ...(open && { display: 'none' }) }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" color="inherit" component="div">
            Address Management System
          </Typography>

        </Toolbar>
      </AppBar>
      <Drawer
        variant="persistent"
        anchor="left"
        open={open}
        sx={{
          width: drawerWidth,
          flexShrink: 0,
          '& .MuiDrawer-paper': {
            width: drawerWidth,
            boxSizing: 'border-box',
          },
        }}
      >
        <div className="row bg-primary">
          <div className="col-12">
            <IconButton className="text-white" onClick={handleDrawerClose}>
              {theme.direction === 'ltr' ? <ChevronLeftIcon /> : <ChevronRightIcon />}
            </IconButton>

          </div>

        </div>
        <Divider />
        <div className="row">
          <div className="col-12">
            <List>
              <ListItemButton component="a" href={REACT_ROUTES.HOME}>
                <ListItemText primary="Home" />
              </ListItemButton>
              <ListItemButton component="a" href={REACT_ROUTES.PERSONSEARCH}>
                <ListItemText primary="People" />
              </ListItemButton>
              <ListItemButton component="a" href={REACT_ROUTES.ADDRESSSEARCH}>
                <ListItemText primary="Addresses" />
              </ListItemButton>
            </List>

          </div>
        </div>
      </Drawer>
    </Fragment>
  );
};

