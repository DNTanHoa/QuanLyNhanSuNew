using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.Security;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [DefaultProperty("nhanVien")]
    [Persistent(@"NguoiDungs")]
    [XafDisplayName("Người Dùng")]
    public class NguoiDung : XPLiteObject, ISecurityUser,
        IAuthenticationStandardUser, IAuthenticationActiveDirectoryUser,
        ISecurityUserWithRoles, IPermissionPolicyUser, ICanInitialize
    {
        public NguoiDung(Session session)
            : base(session) { }

        int fId;
        [Key(true), Browsable(false)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        NhanVien fNhanVien;
        [XafDisplayName("Tên Nhân Viên")]
        public NhanVien nhanVien
        {
            get { return fNhanVien; }
            set { SetPropertyValue("nhanVien", ref fNhanVien, value); }
        }
        #region ISecurityUser Members
        private bool isActive = true;
        [XafDisplayName("Đã Được Kích Hoạt")]
        public bool IsActive
        {
            get { return isActive; }
            set { SetPropertyValue("IsActive", ref isActive, value); }
        }
        private string userName = String.Empty;
        [XafDisplayName("Tên Đăng Nhập")]
        [RuleRequiredField("EmployeeUserNameRequired", DefaultContexts.Save)]
        [RuleUniqueValue("EmployeeUserNameIsUnique", DefaultContexts.Save,
            "Tên Đăng Nhập Đã Được Sử Dụng Vui Lòng Nhập Nội Dung Khác")]
        public string UserName
        {
            get { return userName; }
            set { SetPropertyValue("UserName", ref userName, value); }
        }
        #endregion

        #region IAuthenticationStandardUser Members
        private bool changePasswordOnFirstLogon;
        [XafDisplayName("Đã Thay Đổi Mật Khẩu")]
        public bool ChangePasswordOnFirstLogon
        {
            get { return changePasswordOnFirstLogon; }
            set
            {
                SetPropertyValue("ChangePasswordOnFirstLogon", ref changePasswordOnFirstLogon, value);
            }
        }
        private string storedPassword;
        [Browsable(false), Size(SizeAttribute.Unlimited), Persistent, SecurityBrowsable]
        protected string StoredPassword
        {
            get { return storedPassword; }
            set { storedPassword = value; }
        }
        public bool ComparePassword(string password)
        {
            return PasswordCryptographer.VerifyHashedPasswordDelegate(this.storedPassword, password);
        }
        public void SetPassword(string password)
        {
            this.storedPassword = PasswordCryptographer.HashPasswordDelegate(password);
            OnChanged("StoredPassword");
        }
        #endregion
        #region ISecurityUserWithRoles Members
        IList<ISecurityRole> ISecurityUserWithRoles.Roles
        {
            get
            {
                IList<ISecurityRole> result = new List<ISecurityRole>();
                foreach (EmployeeRole role in EmployeeRoles)
                {
                    result.Add(role);
                }
                return result;
            }
        }
        #endregion
        [Association("NguoiDungs-EmployeeRoles")]
        [RuleRequiredField("EmployeeRoleIsRequired", DefaultContexts.Save,
            TargetCriteria = "IsActive",
            CustomMessageTemplate = "An active employee must have at least one role assigned")]
        public XPCollection<EmployeeRole> EmployeeRoles
        {
            get
            {
                return GetCollection<EmployeeRole>("EmployeeRoles");
            }
        }
        #region IPermissionPolicyUser Members
        IEnumerable<IPermissionPolicyRole> IPermissionPolicyUser.Roles
        {
            get { return EmployeeRoles.OfType<IPermissionPolicyRole>(); }
        }
        #endregion

        #region ICanInitialize Members
        void ICanInitialize.Initialize(IObjectSpace objectSpace, SecurityStrategyComplex security)
        {
            EmployeeRole newUserRole = (EmployeeRole)objectSpace.FindObject<EmployeeRole>(
                new BinaryOperator("Name", security.NewUserRoleName));
            if (newUserRole == null)
            {
                newUserRole = objectSpace.CreateObject<EmployeeRole>();
                newUserRole.Name = security.NewUserRoleName;
                newUserRole.IsAdministrative = true;
                newUserRole.NguoiDungs.Add(this);
            }
        }

        public void Initialize(IObjectSpace objectSpace, SecurityStrategyComplex security)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
