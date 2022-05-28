import jwt_decode from "jwt-decode";

interface decode {
    // aud: string,
    // exp: number,
    // iss: string,
    // nameid: string,
    role: string
}

const getRole = (token: string | null) => {
    if (token){
        var decoded : decode = jwt_decode(token);
        return decoded.role;
    }
    return null;
}

export {getRole}