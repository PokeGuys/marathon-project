using MarathonSystem.Models;

namespace MarathonSystem.Middlewares
{
    static class Auth
    {
        private static Member member;

        public static Member User()
        {
            return member;
        }

        public static void setUser(Member m)
        {
            member = m;
        }

        public static bool isAdmin()
        {
            return guest() ? false : member.state == 99;
        }

        public static bool isSenior()
        {
            return guest() ? false : member.state >= 5;
        }

        public static bool isStaff()
        {
            return guest() ? false : member.state >= 4;
        }

        public static bool isRunner()
        {
            return guest() ? false : member.state == 3;
        }

        public static bool isVolunteer()
        {
            return guest() ? false : member.state == 2;
        }

        public static bool isMember()
        {
            return guest() ? false : member.state == 1;
        }

        public static bool isInactive()
        {
            return guest() ? false : member.state == 0;
        }

        public static bool guest()
        {
            return member == null;
        }

        public static bool check()
        {
            return !guest();
        }

        public static void logout()
        {
            member = null;
        }
    }
}
