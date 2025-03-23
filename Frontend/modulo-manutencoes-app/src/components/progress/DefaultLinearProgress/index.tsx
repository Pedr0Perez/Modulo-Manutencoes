import { memo } from "react";
import { Box } from "@mui/material";
import LinearProgress from "@mui/material/LinearProgress";

const DefaultLinearProgress = (): React.JSX.Element => {
  return (
    <Box sx={{ width: "100%" }}>
      <LinearProgress color="error" />
    </Box>
  );
};

export default memo(DefaultLinearProgress);
