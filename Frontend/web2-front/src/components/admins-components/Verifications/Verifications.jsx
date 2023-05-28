import { useEffect, useState } from "react";
import adminService from "../../../services/adminService";
import classes from "./Verifications.module.css";
import WaitingTable from "./WaitingTable/WaitingTable";
import VerifiedTable from "./VerifiedTable/VerifiedTable";

const Verifications = () => {
  const [waitingUsers, setWaitingUsers] = useState(null);
  const [verifiedUsers, setVerifiedUsers] = useState(null);

  const refresh = () => {
    adminService.getWaitingUsers().then((res) => {
      setWaitingUsers(res.users);
    });

    adminService.getVerifiedUsers().then((res) => {
      setVerifiedUsers(res.users);
    });
  }
  useEffect(() => {
    refresh();
  }, []);

  return (
    <div>
      {
        waitingUsers && waitingUsers.length !== 0 &&
        <>
          <h2 className={classes.heading}>Verifications</h2>
          <WaitingTable users={waitingUsers} refresh={refresh}/>
          <br/>
        </>
      }
      {
        verifiedUsers && verifiedUsers.length !== 0 &&
        <>
          <h2 className={classes.heading}>Verified users</h2>
          <VerifiedTable users={verifiedUsers} />
        </>
      }
    </div>
  );
};

export default Verifications;
