
var KBCount = 1024;
var MBCount = KBCount * 1024;
var GBCount = MBCount * 1024;
var TBCount = GBCount * 1024;

function getFileSize(lenght) {
    if (KBCount > lenght) {
        return Math.round(lenght, 1) + "B";
    }
    else if (MBCount > lenght) {
        return Math.round(lenght / KBCount, 1) + "KB";
    }
    else if (GBCount > lenght) {
        return Math.round(size / MBCount, 1) + "MB";
    }
    else if (TBCount > lenght) {
        return Math.round(lenght / GBCount, 1) + "GB";
    }
    else {
        return Math.round(lenght / TBCount, 1) + "TB";
    }
}
