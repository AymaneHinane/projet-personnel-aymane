const passport = require('passport');
const JwtStrategy = require('passport-jwt').Strategy;
const ExtractJwt = require('passport-jwt').ExtractJwt;
const User = require('../models/userModel');

const options = {
  jwtFromRequest: ExtractJwt.fromAuthHeaderAsBearerToken(),
  secretOrKey: 'hsgsg5-twtyqyqy9-ayayst0', // Change this to a strong, secure secret key
};

passport.use(
  new JwtStrategy(options, async (jwt_payload, done) => {
    try {
      const user = await User.findById(jwt_payload.id);
      if (user) {
        return done(null, user);
      } else {
        return done(null, false);
      }
    } catch (error) {
      return done(error, false);
    }
  })
);

const authenticate = (roles) => {
  return (req, res, next) => {
    passport.authenticate('jwt', { session: false }, (err, user) => {
      if (err) {
        return res.status(500).json({ error: err.message });
      }
      if (!user) {
        return res.status(401).json({ message: 'Unauthorized' });
      }
      if (roles.includes(user.role)) {
        req.user = user;
        next();
      } else {
        return res.status(403).json({ message: 'Forbidden' });
      }
    })(req, res, next);
  };
};

module.exports = { passport, authenticate };
