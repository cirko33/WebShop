import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, Slide } from "@mui/material";
import { forwardRef } from "react";

const Transition = forwardRef(function Transition(props, ref) {
    return <Slide direction="up" ref={ref} {...props} />;
  });

const ConfirmDialog = ({open, setOpen, data}) => {
    return ( <Dialog
        open={open}
        TransitionComponent={Transition}
        keepMounted
        onClose={e => setOpen(false)}
        aria-describedby="alert-dialog-slide-description"
      >
        <DialogTitle>Confirm your order</DialogTitle>
        <DialogActions>
          <Button color="error" onClose={e => setOpen(false)}>Cancel</Button>
          <Button color="success" onClick={e => {setConfirmed(true); setOpen(false);}}>Confirm</Button>
        </DialogActions>
      </Dialog> );
}
 
export default ConfirmDialog;