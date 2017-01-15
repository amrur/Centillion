//#define debug
// This custom permission is intended only for the purposes of illustration.
// The following code shows how to create a custom permission that inherits
// from CodeAccessPermission. The code implements all required overrides.
// A wildcard character ('*') is implemented for the Name property.
using System;
using System.Security;
using System.Security.Permissions;

[assembly: System.Reflection.AssemblyKeyFile("Key.snk")]
[assembly: System.Security.AllowPartiallyTrustedCallersAttribute()]

namespace MyPermission
{
    [Serializable()]
    sealed public class NameIdPermission : CodeAccessPermission, IUnrestrictedPermission
    {
        private string m_Name;
        private bool m_Unrestricted;

        public NameIdPermission(string name)
        {
            m_Name = name;
        }

        public NameIdPermission(PermissionState state)
        {
            if (state == PermissionState.None)
            {
                m_Name = "";
            }
            else
                if (state == PermissionState.Unrestricted)
            {
                throw new ArgumentException("Unrestricted state is not allowed for identity permissions.");
            }
            else throw new ArgumentException("Invalid permission state.");
        }

        public string Name
        {
            set { m_Name = value; }
            get { return m_Name; }
        }
        public override IPermission Copy()
        {
            string name = m_Name;
            return new NameIdPermission(name);
        }
        public bool IsUnrestricted()
        {
            // Always false, unrestricted state is not allowed.
            return m_Unrestricted;
        }

        private bool VerifyType(IPermission target)
        {
            return (target is NameIdPermission);
        }
        public override bool IsSubsetOf(IPermission target)
        {
#if(debug)
            Console.WriteLine ("************* Entering IsSubsetOf *********************");
#endif
            if (target == null)
            {
                Console.WriteLine("IsSubsetOf: target == null");
                return false;
            }
#if(debug)

            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            try
            {
                NameIdPermission operand = (NameIdPermission)target;

                // The following check for unrestricted permission is only included as an example for
                // permissions that allow the unrestricted state. It is of no value for this permission.
                if (true == operand.m_Unrestricted)
                {
                    return true;
                }
                else if (true == m_Unrestricted)
                {
                    return false;
                }

                if (m_Name != null)
                {
                    if (operand.m_Name == null) return false;

                    if (m_Name == "") return true;
                }

                if (m_Name.Equals(operand.m_Name)) return true;
                else
                {
                    // Check for wild card character '*'.
                    int i = operand.m_Name.LastIndexOf("*");

                    if (i > 0)
                    {
                        string prefix = operand.m_Name.Substring(0, i);

                        if (m_Name.StartsWith(prefix))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException(string.Format("Argument_WrongType", GetType().FullName));
            }
        }
        public override IPermission Intersect(IPermission target)
        {
            Console.WriteLine("************* Entering Intersect *********************");
            if (target == null)
            {
                return null;
            }
#if(debug)
            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            if (!VerifyType(target))
            {
                throw new ArgumentException(string.Format("Argument is wrong type.", GetType().FullName));
            }

            NameIdPermission operand = (NameIdPermission)target;

            if (operand.IsSubsetOf(this)) return operand.Copy();
            else if (IsSubsetOf(operand)) return Copy();
            else
                return null;
        }

        public override IPermission Union(IPermission target)
        {
#if(debug)
            Console.WriteLine ("************* Entering Union *********************");
#endif
            if (target == null)
            {
                return this;
            }
#if(debug)
            Console.WriteLine ("This is = " + (( NameIdPermission)this).Name);
            Console.WriteLine ("Target is " + (( NameIdPermission)target).m_Name);
#endif
            if (!VerifyType(target))
            {
                throw new ArgumentException(string.Format("Argument_WrongType", GetType().FullName));
            }

            NameIdPermission operand = (NameIdPermission)target;

            if (operand.IsSubsetOf(this)) return Copy();
            else if (IsSubsetOf(operand)) return operand.Copy();
            else
                return null;
        }

        public override void FromXml(SecurityElement e)
        {
            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            string elUnrestricted = e.Attribute("Unrestricted");
            if (null != elUnrestricted)
            {
                m_Unrestricted = bool.Parse(elUnrestricted);
                return;
            }

            string elName = e.Attribute("Name");
            m_Name = elName == null ? null : elName;
        }
        public override SecurityElement ToXml()
        {
            // Use the SecurityElement class to encode the permission to XML.
            SecurityElement esd = new SecurityElement("IPermission");
            string name = typeof(NameIdPermission).AssemblyQualifiedName;
            esd.AddAttribute("class", name);
            esd.AddAttribute("version", "1.0");

            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            if (m_Unrestricted)
            {
                esd.AddAttribute("Unrestricted", true.ToString());
            }
            if (m_Name != null) esd.AddAttribute("Name", m_Name);
            return esd;
        }
    }
}